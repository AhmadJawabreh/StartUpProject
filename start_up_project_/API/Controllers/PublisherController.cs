using Repoistories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using Resources;
using System.Collections.Generic;

namespace API.Controllers
{

    [Route("publisher")]
    [ApiController]
    public class PublisherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public PublisherController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public object GetAll() 
        {
            try
            {

                List<PublisherResource> publisherResources = new List<PublisherResource>();

                IEnumerable<Publisher> Publishers = _unitOfWork.Publishers.GetAll();

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

            }catch(Exception Error) {
                Console.WriteLine(Error.ToString());
                return NotFound();
            }
        }


        [HttpGet("{id}")]
        public object Details([FromRoute] int id)
        {
            try
            {
                PublisherResource publisherResource = new PublisherResource();
                Publisher publisher =  _unitOfWork.Publishers.GetById(id);
                publisherResource.Id = publisher.Id;
                publisherResource.Name = publisher.Name;
                publisherResource.Email = publisher.Email;
                publisherResource.Address = publisher.Address;
                publisherResource.Phone = publisher.Phone;
                return publisherResource;
            }
            catch (Exception Error) {
                Console.WriteLine(Error.ToString());
                return NotFound();
            }
        }


        [HttpPost]
        public ActionResult Create([FromBody] PublisherModel PublisherModel)
        {
            try
            {
                Publisher publisher = new Publisher();
                publisher.Name = PublisherModel.FirstName.Trim() + PublisherModel.LastName.Trim();
                publisher.Email = PublisherModel.Email.Trim();
                publisher.Phone = PublisherModel.Phone.Trim();
                publisher.Address = PublisherModel.StreetNumber.Trim() + ","+PublisherModel.StreetName.Trim() + "," 
                                    + PublisherModel.CityName.Trim() + ","+ PublisherModel.StateName.Trim();

               
                _unitOfWork.Publishers.Insert(publisher);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }


        [HttpPut]
        public ActionResult Update([FromBody] PublisherModel PublisherModel)
        {
            try
            {
                Publisher publisher = _unitOfWork.Publishers.GetById(PublisherModel.Id);
                publisher.Name = PublisherModel.FirstName.Trim() + PublisherModel.LastName.Trim();
                publisher.Email = PublisherModel.Email.Trim();
                publisher.Phone = PublisherModel.Phone.Trim();
                publisher.Address = PublisherModel.StreetNumber.Trim() + "," + PublisherModel.StreetName.Trim() + ","
                                    + PublisherModel.CityName.Trim() + "," + PublisherModel.StateName.Trim();
                _unitOfWork.Publishers.Update(publisher);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                _unitOfWork.Publishers.Delete(id);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return NotFound();
            }
        }
    }
}
