using BusinessLogic.IManagers;
using BusinessLogic.Mappers;
using Entities;
using Models;
using Repoistories;
using Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public class AuthorManager : IAuthorManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorManager(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public List<AuthorResource> GetAll(int PageNumber, int PageSize)
        {
            PageSize = PageSize < 15 ? 15 : PageSize;
            PageNumber = PageNumber < 1 ? 1 : PageNumber;
            
            List<Author> authors = _unitOfWork.Athuors.GetAll(item => true, PageNumber, PageSize);
            return AuthorMapper.ToResources(authors);
        }

        public async Task<AuthorResource> GetByIdAsync(long Id)
        {
            Author author = await _unitOfWork.Athuors.GetById(Id);
            if (author == null)
            {
                throw new Exception("This Author does not found.");
            }
            return AuthorMapper.ToResource(author);
        }

        public async Task<AuthorResource> InsertAsync(AuthorModel authorModel)
        {
            Author author = new Author();
            author = AuthorMapper.ToEntity(author, authorModel);
            await _unitOfWork.Athuors.Create(author);
            await _unitOfWork.Save();
            return AuthorMapper.ToResource(author);
        }

        public async Task<AuthorResource> UpdateAsync(AuthorModel authorModel)
        {
            Author author = await _unitOfWork.Athuors.GetById(authorModel.Id);
            if (author == null)
            {
                throw new Exception("This Author does not found.");
            }
            author = AuthorMapper.ToEntity(author, authorModel);
            _unitOfWork.Athuors.Update(author);
            await _unitOfWork.Save();
            return AuthorMapper.ToResource(author);
        }

        public async Task DeleteAsync(long Id)
        {
            Author author = await _unitOfWork.Athuors.GetById(Id);
            if (author == null)
            {
                throw new Exception("This Author does not found.");
            }
            _unitOfWork.Athuors.Delete(author);
            await _unitOfWork.Save();
        }
    }
}
