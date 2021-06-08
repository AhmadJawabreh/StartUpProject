using Repoistories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using BusinessLogic.IManagers;
using Resources;
using System.Collections.Generic;

namespace API.Controllers
{

    [Route("publisher")]
    [ApiController]
    public class PublisherController : Controller
    {
        private readonly IPublisherManager _PublisherManager;
       
        public PublisherController(IPublisherManager PublisherManager) 
        {
              this._PublisherManager = PublisherManager;
        }

        [HttpGet]
        public List<PublisherResource> GetAll() 
        {
            try
            {
               return  this._PublisherManager.GetAll();
            }
            catch(Exception Error) {
                throw Error;
            }
        }


        [HttpGet("{Id}")]
        public PublisherResource Details([FromRoute] int Id)
        {
            try
            {
               return this._PublisherManager.GetById(Id);
            }
            catch (Exception Error) {
                throw Error;
            }
        }


        [HttpPost]
        public void Create([FromBody] PublisherModel PublisherModel)
        {
            try
            {
                this._PublisherManager.Insert(PublisherModel);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }


        [HttpPut]
        public void Update([FromBody] PublisherModel PublisherModel)
        {
            try
            {
                this._PublisherManager.Update(PublisherModel);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }


        [HttpDelete("{Id}")]
        public void Delete([FromRoute] int Id)
        {
            try
            {
                this._PublisherManager.Delete(Id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
