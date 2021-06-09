using BusinessLogic.IManagers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<List<PublisherResource>> GetAllAsync()
        {
            try
            {
                return await this._PublisherManager.GetAllAsync();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpGet("{Id}")]
        public async Task<PublisherResource> Details([FromRoute] int Id)
        {
            try
            {
                return await this._PublisherManager.GetByIdAsync(Id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpPost]
        public async Task<PublisherResource> Create([FromBody] PublisherModel PublisherModel)
        {
            try
            { 
                return await this._PublisherManager.InsertAsync(PublisherModel);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpPut]
        public async Task<PublisherResource> Update([FromBody] PublisherModel PublisherModel)
        {
            try
            {
                return await this._PublisherManager.UpdateAsync(PublisherModel);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            try
            {
                await this._PublisherManager.DeleteAsync(Id);
                return NoContent();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
