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
    public class PublisherManager : IPublisherManager
    {
        private readonly IUnitOfWork _UnitOfWork;

        public PublisherManager(IUnitOfWork UnitOfWork) {

            this._UnitOfWork = UnitOfWork;
        }

        public async Task<List<PublisherResource>> GetAllAsync()
        {
            try
            {
                IEnumerable<Publisher> Publishers = await _UnitOfWork.Publishers.GetAll();
                return PublisherMapper.ToResources(Publishers);
            }
            catch (Exception Error)
            {
                throw Error;
            }   
        }

        public async Task<PublisherResource> GetByIdAsync(long Id)
        {
            try
            {
                Publisher publisher = await _UnitOfWork.Publishers.GetById(Id);
                if (publisher == null) 
                {
                    return null;
                }
                return PublisherMapper.ToResource(publisher);
            }
            catch (Exception Error) 
            {
                throw Error;
            }
        }

        

        public async Task<PublisherResource> InsertAsync(PublisherModel publisherModel)
        {
            try
            {
                if (publisherModel.Phone == null ||
                    publisherModel.Phone.Trim().Length == 0 &&
                    publisherModel.Email == null ||
                    publisherModel.Email.Trim().Length == 0) {

                    throw new Exception("You Should enter phome or email");
                
                }

                    Publisher publisher = new Publisher();
                publisher = PublisherMapper.ToEntity(publisher, publisherModel);
                await _UnitOfWork.Publishers.Insert(publisher);
                await _UnitOfWork.Save();
                return PublisherMapper.ToResource(publisher);
            }
            catch (Exception Error) 
            {
                throw Error;   
            }
        }

        public async Task<PublisherResource> UpdateAsync(PublisherModel publisherModel)
        {
            try
            {
                Publisher publisher = await _UnitOfWork.Publishers.GetById(publisherModel.Id);
                if (publisher == null)
                {
                    return null;
                }       
                 publisher = PublisherMapper.ToEntity(publisher, publisherModel);
                _UnitOfWork.Publishers.Update(publisher);
                await _UnitOfWork.Save();
                return PublisherMapper.ToResource(publisher);
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
               await _UnitOfWork.Publishers.Delete(Id);
               await  _UnitOfWork.Save();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
