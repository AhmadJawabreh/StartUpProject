﻿using BusinessLogic.IManagers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Resources;
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
            List<PublisherResource> publisherResources = _PublisherManager.GetAll(PageNumber, PageSize);
            return Ok(publisherResources);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details([FromRoute] int Id)
        {
            PublisherResource publisherResource = await _PublisherManager.GetByIdAsync(Id);
            return Ok(publisherResource);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PublisherModel PublisherModel)
        {
            PublisherResource publisherResource = await _PublisherManager.InsertAsync(PublisherModel);
            return Ok(publisherResource);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PublisherModel PublisherModel)
        {
            PublisherResource publisherResource = await _PublisherManager.UpdateAsync(PublisherModel);
            return Ok(publisherResource);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            await _PublisherManager.DeleteAsync(Id);
            return Ok();
        }
    }
}
