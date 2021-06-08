using Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IManagers
{
    public interface IPublisherManager
    {
        public Task<List<PublisherResource>> GetAllAsync();
        public Task<PublisherResource> GetByIdAsync(long Id);
        public Task<PublisherResource> InsertAsync(PublisherModel publisherModel);
        public Task<PublisherResource> UpdateAsync(PublisherModel publisherModel);
        public Task DeleteAsync(long Id);
    }
}
