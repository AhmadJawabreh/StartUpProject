using Entities;
using Models;
using Resources;
using System.Collections.Generic;

namespace BusinessLogic.Mappers
{
    class PublisherMapper
    {    
       
        public static List<PublisherResource> ToResources(IEnumerable<Publisher> Publishers)
        {
            List<PublisherResource> publisherResources = new List<PublisherResource>();
            foreach (var Item in Publishers)
            {
                publisherResources.Add(new PublisherResource
                    {
                        Id = Item.Id,
                        Name = Item.Name,
                        Email = Item.Email,
                        Address = Item.Address,
                        Phone = Item.Phone
                    }
                );
            }
            return publisherResources;
        }

        public static PublisherResource ToResource(Publisher publisher) 
        {
            PublisherResource publisherResource = new PublisherResource();
            publisherResource.Id = publisher.Id;
            publisherResource.Name = publisher.Name;
            publisherResource.Email = publisher.Email;
            publisherResource.Address = publisher.Address;
            publisherResource.Phone = publisher.Phone;
            return publisherResource;
        }

        public static Publisher ToEntity(Publisher publisher,PublisherModel publisherModel)
        {
            publisher.Name = publisherModel.FirstName.Trim() + publisherModel.LastName.Trim();
            publisher.Email = publisherModel.Email.Trim();
            publisher.Phone = publisherModel.Phone.Trim();
            publisher.Address = publisherModel.StreetNumber.Trim() + "," + publisherModel.StreetName.Trim() + ","
                                + publisherModel.CityName.Trim() + "," + publisherModel.StateName.Trim();
            return publisher;
        }
    }
}
