using BusinessLogic.IManagers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Resources;
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
        public IActionResult GetAllAsync(int PageNumber = 1, int PageSize = 15)
        {
            List<AuthorResource> authorResources = this._authorManager.GetAll(PageNumber, PageSize);
            return Ok(authorResources);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> DetailsAsync([FromRoute] long Id)
        {
            AuthorResource author = await this._authorManager.GetByIdAsync(Id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AuthorModel authorModel)
        {
            AuthorResource authorResource = await this._authorManager.InsertAsync(authorModel);
            return Ok(authorResource);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AuthorModel authorModel)
        {
            AuthorResource authorResource = await this._authorManager.UpdateAsync(authorModel);
            return Ok(authorResource);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long Id)
        {
            await this._authorManager.DeleteAsync(Id);
            return Ok();
        }
    }
}
