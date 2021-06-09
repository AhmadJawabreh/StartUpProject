using Models;
using Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.IManagers
{
    public interface IPublisherManager
    {
         Task<List<PublisherResource>> GetAllAsync();
         Task<PublisherResource> GetByIdAsync(long Id);
         Task<PublisherResource> InsertAsync(PublisherModel publisherModel);
         Task<PublisherResource> UpdateAsync(PublisherModel publisherModel);
         Task DeleteAsync(long Id);
    }
}
