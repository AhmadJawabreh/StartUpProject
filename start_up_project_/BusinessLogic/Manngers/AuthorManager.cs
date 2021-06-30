using BusinessLogic.Mappers;
using Contract.Exceptions;
using Contract.RabbitMQ;
using Producer;
using Entities;
using ENUM;
using Filters;
using Models;
using Repoistories;
using Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public interface IAuthorManager
    {
        List<AuthorResource> GetAll(Filter filter);
        Task<AuthorResource> GetByIdAsync(long id);
        Task<AuthorResource> InsertAsync(AuthorModel authorModel);
        Task<AuthorResource> UpdateAsync(AuthorModel authorModel);
        Task DeleteAsync(long id);
    }

    public class AuthorManager : IAuthorManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISender _sender;

        public AuthorManager(IUnitOfWork unitOfWork, ISender sender)
        {
            this._unitOfWork = unitOfWork;
            this._sender = sender;
        }

        public List<AuthorResource> GetAll(Filter filter)
        {

            if (filter.PageNumber <= 0)
            {
                throw new InvalidArgumentException("Page Number must be more than 0.");
            }

            if (filter.PageSize < 10)
            {
                throw new InvalidArgumentException("Page Size must be more than 10.");
            }

            List<Author> authors = _unitOfWork.Athuors.GetAll(filter);
            return AuthorMapper.ToResources(authors);
        }

        public async Task<AuthorResource> GetByIdAsync(long Id)
        {
            Author author = await _unitOfWork.Athuors.GetById(Id);
            if (author == null)
            {
                throw new NotFoundException("This Author does not found.");
            }
            return AuthorMapper.ToResource(author);
        }

        public async Task<AuthorResource> InsertAsync(AuthorModel authorModel)
        {
            Author author = new Author();
            author = AuthorMapper.ToEntity(author, authorModel);
            await _unitOfWork.Athuors.Create(author);
            await _unitOfWork.Save();

            Message message = new Message
            {
                id = author.Id,
                operationType = OperationType.Create,
                dirtyEntityType = DirtyEntityType.Author
            };

            this._sender.Send(message);
            return AuthorMapper.ToResource(author);
        }

        public async Task<AuthorResource> UpdateAsync(AuthorModel authorModel)
        {
            Author author = await _unitOfWork.Athuors.GetById(authorModel.Id);
            if (author == null)
            {
                throw new NotFoundException("This Author does not found.");
            }
            author = AuthorMapper.ToEntity(author, authorModel);
            _unitOfWork.Athuors.Update(author);
            await _unitOfWork.Save();
            Message message = new Message
            { 
                id = author.Id,
                operationType = OperationType.Update,
                dirtyEntityType = DirtyEntityType.Author
            };

            this._sender.Send(message);
            return AuthorMapper.ToResource(author);
        }

        public async Task DeleteAsync(long Id)
        {
            Author author = await _unitOfWork.Athuors.GetById(Id);
            if (author == null)
            {
                throw new NotFoundException("This Author does not found.");
            }
            Message message = new Message
            {
                id = author.Id,
                operationType = OperationType.Delete,
                dirtyEntityType = DirtyEntityType.Author
            };

            this._sender.Send(message);
            _unitOfWork.Athuors.Delete(author);

            await _unitOfWork.Save();
        }
    }
}
