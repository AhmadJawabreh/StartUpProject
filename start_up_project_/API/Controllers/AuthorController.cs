using BusinessLogic;
using Contract.Filters;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace API.Controllers
{


    [Route("Author")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorManager _authorManager;

        public AuthorController(IAuthorManager authorManager)
        {
            this._authorManager = authorManager;
        }

        [HttpGet]
        public IActionResult GetAllAsync([FromQuery] Filter filter)
        {
            List<AuthorResource> authorResources = _authorManager.GetAll(filter);
            return Ok(authorResources);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> DetailsAsync([FromRoute] long Id)
        {
            AuthorResource author = await _authorManager.GetByIdAsync(Id);
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long Id)
        {
            await _authorManager.DeleteAsync(Id);
            return Ok();
        }
    }
}
