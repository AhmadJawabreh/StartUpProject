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

        public PublisherManager(IUnitOfWork UnitOfWork)
        {
            this._UnitOfWork = UnitOfWork;
        }

        public  List<PublisherResource> GetAll(int PageNumber, int PageSize)
        {
            PageSize = PageSize < 15 ? 15 : PageSize;
            PageNumber = PageNumber < 1 ? 1 : PageNumber;
            List<Publisher> publishers =  _UnitOfWork.Publishers.GetAll(item => true, PageNumber, PageSize);
            return PublisherMapper.ToResources(publishers);
        }

        public async Task<PublisherResource> GetByIdAsync(long Id)
        {
            Publisher publisher = await _UnitOfWork.Publishers.GetById(Id);
            if (publisher == null)
            {
                throw new Exception("This publisher does not found");
            }
            return PublisherMapper.ToResource(publisher);
        }
      

        public async Task<PublisherResource> InsertAsync(PublisherModel publisherModel)
        {
            bool IsPhoneEmpty = (publisherModel.Phone == null || publisherModel.Phone?.Trim().Length == 0);
            bool IsEmailEmpty = (publisherModel.Email == null || publisherModel.Email?.Trim().Length == 0);
            if (IsPhoneEmpty && IsEmailEmpty)
            {
                throw new Exception("You Should enter phome or email");
            }

            Publisher publisher = new Publisher();
            publisher = PublisherMapper.ToEntity(publisher, publisherModel);
            await _UnitOfWork.Publishers.Create(publisher);
            await _UnitOfWork.Save();
            return PublisherMapper.ToResource(publisher);
        }

        public async Task<PublisherResource> UpdateAsync(PublisherModel publisherModel)
        {
            Publisher publisher = await _UnitOfWork.Publishers.GetById(publisherModel.Id);
            if (publisher == null)
            {
                throw new Exception("This Publisher does not found");
            }
            publisher = PublisherMapper.ToEntity(publisher, publisherModel);
            _UnitOfWork.Publishers.Update(publisher);
            await _UnitOfWork.Save();
            return PublisherMapper.ToResource(publisher);
        }

        public async Task DeleteAsync(long Id)
        {
            Publisher publisher = await _UnitOfWork.Publishers.GetById(Id);
            if (publisher == null)
            {
                throw new Exception("This Publisher does not found");
            }
            _UnitOfWork.Publishers.Delete(publisher);
            await _UnitOfWork.Save();
        }
    }
}
