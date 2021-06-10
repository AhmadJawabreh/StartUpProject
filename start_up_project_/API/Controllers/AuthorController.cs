using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using Resources;
using BusinessLogic.IManagers;
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
        public  IActionResult GetAllAsync(int PageNumber = 1, int PageSize = 15)
        {
            try
            {
                List<AuthorResource> authorResources =  this._authorManager.GetAll(PageNumber, PageSize);
                return Ok(authorResources);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> DetailsAsync([FromRoute] long Id)
        {
            try
            {
                AuthorResource author =  await this._authorManager.GetByIdAsync(Id);
                return Ok(author);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AuthorModel authorModel)
        {
            try
            {
                AuthorResource authorResource =  await this._authorManager.InsertAsync(authorModel);
                return Ok(authorResource);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AuthorModel authorModel)
        {
            try
            {
                AuthorResource authorResource =  await this._authorManager.UpdateAsync(authorModel);
                return Ok(authorResource);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long Id)
        {
            try
            {
                await this._authorManager.DeleteAsync(Id);
                return Ok();
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }
    }
}
