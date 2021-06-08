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
    class PublisherManager : IPublisherManager
    {
        private readonly IUnitOfWork _UnitOfWork;

        public PublisherManager(IUnitOfWork UnitOfWork) {

            this._UnitOfWork = UnitOfWork;
        }

        public List<PublisherResource> GetAll()
        {
            try
            {
                IEnumerable<Publisher> Publishers = _UnitOfWork.Publishers.GetAll();
                return PublisherMapper.ConvertToListOfPublisherResources(Publishers);
            }
            catch (Exception Error)
            {
                throw Error;
            }   
        }

        public PublisherResource GetById(long id)
        {
            try
            {
                Publisher publisher = _UnitOfWork.Publishers.GetById(id);
                return PublisherMapper.ConvertToPublisherResource(publisher);
            }
            catch (Exception Error) 
            {
                throw Error;
            }
        }

        

        public void Insert(PublisherModel publisherModel)
        {
            try
            {
                Publisher publisher = PublisherMapper.ConvertToPublisher(publisherModel);
                _UnitOfWork.Publishers.Insert(publisher);
                _UnitOfWork.Save();
            }
            catch (Exception Error) 
            {
                throw Error;   
            }
        }

        public void Update(PublisherModel publisherModel)
        {
            try
            {
                Publisher CurrentPublisher = _UnitOfWork.Publishers.GetById(publisherModel.Id);
                Publisher NewPublisher = 
                _UnitOfWork.Publishers.Update(publisher);
                _UnitOfWork.Save();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
            }
        }

        public void Delete(long Id)
        {
            try
            {
                _UnitOfWork.Publishers.Delete(Id);
                _UnitOfWork.Save();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
            }
        }
    }
}
