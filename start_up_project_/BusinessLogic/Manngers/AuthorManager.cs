using BusinessLogic.IManagers;
using BusinessLogic.Mappers;
using Entities;
using Models;
using Repoistories;
using Resources;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class AuthorManager : IAuthorManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorManager(IUnitOfWork unitOfWork) 
        {
            this._unitOfWork = unitOfWork;
        }

        public List<AuthorResource> GetAll()
        {
            try
            {
                IEnumerable<Author> authors = this._unitOfWork.Athuors.GetAll();
                return AuthorMapper.ConvertToListOfAuthorResources(authors);
            }
            catch (Exception Error)
            {
                return null;
            }
        }

        public AuthorResource GetById(long Id)
        {
            try
            {
                Author author = this._unitOfWork.Athuors.GetById(Id);
                if(author == null)
                    return null;
                return AuthorMapper.ConvertToAuthorResources(author);
            }
            catch (Exception Error) 
            {
                return null;   
            }
        }

        public void Insert(AuthorModel authorModel)
        {
            try
            {
                Author author = AuthorMapper.ConvertToAuthorModel(authorModel);
                this._unitOfWork.Athuors.Insert(author);
                this._unitOfWork.Save();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public void Update(AuthorModel authorModel)
        {
            try
            {
                Author author = AuthorMapper.ConvertToAuthorModel(authorModel);
                this._unitOfWork.Athuors.Update(author);
                this._unitOfWork.Save();
            }
            catch (Exception Error) 
            {
                throw Error;
            }
        }

        public void Delete(long Id)
        {
            try
            {
                this._unitOfWork.Athuors.Delete(Id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
