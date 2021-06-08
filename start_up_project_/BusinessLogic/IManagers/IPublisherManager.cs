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
        public List<PublisherResource> GetAll();
        public PublisherResource GetById(long Id);
        public void Insert(PublisherModel publisherModel);
        public void Update(PublisherModel publisherModel);
        public void Delete(long Id);
    }
}
