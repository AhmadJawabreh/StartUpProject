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

        public async Task<List<AuthorResource>> GetAllAsync()
        {
            try
            {
                IEnumerable<Author> authors = await this._unitOfWork.Athuors.GetAll();
                return AuthorMapper.ToResources(authors);
            }
            catch (Exception Error)
            {
                return null;
            }
        }

        public async Task<AuthorResource> GetByIdAsync(long Id)
        {
            try
            {
                Author author = await this._unitOfWork.Athuors.GetById(Id);
                if(author == null)
                    return null;
                return AuthorMapper.ToResource(author);
            }
            catch (Exception Error) 
            {
                return null;   
            }
        }

        public async Task<AuthorResource> InsertAsync(AuthorModel authorModel)
        {
            try
            {
                Author author = new Author();
                author = AuthorMapper.ToEntity(author, authorModel);
                await this._unitOfWork.Athuors.Insert(author);
                await this._unitOfWork.Save();
                return AuthorMapper.ToResource(author);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public async Task<AuthorResource> UpdateAsync(AuthorModel authorModel)
        {
            try
            {
                Author author = await _unitOfWork.Athuors.GetById(authorModel.Id);
                author = AuthorMapper.ToEntity(author, authorModel);
                this._unitOfWork.Athuors.Update(author);
                await this._unitOfWork.Save();
                return AuthorMapper.ToResource(author);
            }
            catch (Exception Error) 
            {
                throw Error;
            }
        }

        public async Task DeleteAsync(long Id)
        {
            try
            {
                await this._unitOfWork.Athuors.Delete(Id);
                await this._unitOfWork.Save();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
