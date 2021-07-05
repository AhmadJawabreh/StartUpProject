using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Models;
using Resources;

namespace API.Controllers
{

    [Route("Author")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorManager _authorManager;

        public AuthorController(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }

        [HttpGet]
        public IActionResult GetAllAsync([FromQuery] Filter filter)
        {
            List<AuthorResource> authorResources = _authorManager.GetAll(filter);
            return Ok(authorResources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DetailsAsync([FromRoute] long id)
        {
            AuthorResource author = await _authorManager.GetByIdAsync(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AuthorModel authorModel)
        {
            AuthorResource authorResource = await _authorManager.InsertAsync(authorModel);
            return Ok(authorResource);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AuthorModel authorModel)
        {
            AuthorResource authorResource = await _authorManager.UpdateAsync(authorModel);
            return Ok(authorResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            await _authorManager.DeleteAsync(id);
            return Ok();
        }
    }
}
