﻿using Entities;
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
                        FirstName = Item.FirstName,
                        LastName = Item.LastName,
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
            publisherResource.FirstName = publisher.FirstName;
            publisherResource.LastName = publisher.LastName;
            publisherResource.Email = publisher.Email;
            publisherResource.Address = publisher.Address;
            publisherResource.Phone = publisher.Phone;
            return publisherResource;
        }

        public static Publisher ToEntity(Publisher publisher,PublisherModel publisherModel)
        {
            publisher.FirstName = publisherModel.FirstName.Trim();
            publisher.LastName = publisherModel.LastName.Trim();
            publisher.Email = publisherModel.Email?.Trim();
            publisher.Phone = publisherModel.Phone?.Trim();
            publisher.Address = publisherModel.Address?.Trim();
            return publisher;
        }


    }
}
