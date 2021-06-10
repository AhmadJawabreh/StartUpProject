using BusinessLogic.IManagers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{

    [Route("Publisher")]
    [ApiController]
    public class PublisherController : Controller
    {
        private readonly IPublisherManager _PublisherManager;

        public PublisherController(IPublisherManager PublisherManager)
        {
            this._PublisherManager = PublisherManager;
        }

        [HttpGet]
        public IActionResult GetAllAsync(int PageNumber = 1, int PageSize = 15)
        {
            try
            {
                List<PublisherResource> publisherResources =  this._PublisherManager.GetAll(PageNumber,PageSize);
                return Ok(publisherResources);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details([FromRoute] int Id)
        {
            try
            {
                PublisherResource publisherResource = await this._PublisherManager.GetByIdAsync(Id);
                return Ok(publisherResource);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PublisherModel PublisherModel)
        {
            try
            {
                PublisherResource publisherResource = await this._PublisherManager.InsertAsync(PublisherModel);
                return Ok(publisherResource);

            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PublisherModel PublisherModel)
        {
            try
            {
                PublisherResource publisherResource = await this._PublisherManager.UpdateAsync(PublisherModel);
                return Ok(publisherResource);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            try
            {
                await this._PublisherManager.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }
    }
}
