using BusinessLogic.IManagers;
using BusinessLogic.Mappers;
using BusinessLogic.Parsers;
using Entities;
using Models;
using Repoistories;
using Resources;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class PublisherManager : IPublisherManager
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

        public PublisherResource GetById(long Id)
        {
            try
            {
                Publisher publisher = _UnitOfWork.Publishers.GetById(Id);
                if (publisher == null) 
                {
                    return null;
                }
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
                Publisher OldPublisherData = _UnitOfWork.Publishers.GetById(publisherModel.Id);
                if (OldPublisherData == null)
                {
                    return;
                }
                Publisher NewPublisherData = PublisherMapper.ConvertToPublisher(publisherModel);
                Publisher publisher = PublisherParser.Parser(OldPublisherData, NewPublisherData);
                _UnitOfWork.Publishers.Update(publisher);
                _UnitOfWork.Save();
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
                _UnitOfWork.Publishers.Delete(Id);
                _UnitOfWork.Save();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
