using BusinessLogic;
using Filters;
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
        private readonly IPublisherManager _publisherManager;

        public PublisherController(IPublisherManager publisherManager)
        {
            _publisherManager = publisherManager;
        }

        [HttpGet]
        public IActionResult GetAllAsync([FromQuery] Filter filter)
        {
            List<PublisherResource> publisherResources = _publisherManager.GetAll(filter);
            return Ok(publisherResources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            PublisherResource publisherResource = await _publisherManager.GetByIdAsync(id);
            return Ok(publisherResource);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PublisherModel PublisherModel)
        {
            PublisherResource publisherResource = await _publisherManager.InsertAsync(PublisherModel);
            return Ok(publisherResource);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PublisherModel publisherModel)
        {
            PublisherResource publisherResource = await _publisherManager.UpdateAsync(publisherModel);
                return Ok(publisherResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _publisherManager.DeleteAsync(id);
            return Ok();
        }
    }
}
