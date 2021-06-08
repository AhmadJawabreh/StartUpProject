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
        public async Task<List<AuthorResource>> GetAllAsync()
        {
            try
            {
                return await this._authorManager.GetAllAsync();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpGet("{Id}")]
        public async Task<AuthorResource> DetailsAsync([FromRoute] long Id)
        {
            try
            {
                return await this._authorManager.GetByIdAsync(Id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpPost]
        public async Task<AuthorResource> AddAsync([FromBody] AuthorModel authorModel)
        {
            try
            {
                return await this._authorManager.InsertAsync(authorModel);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpPut]
        public async Task<AuthorResource> Update([FromBody] AuthorModel authorModel)
        {
            try
            {
                return await this._authorManager.UpdateAsync(authorModel);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long Id)
        {
            try
            {
                await this._authorManager.DeleteAsync(Id);
                return NoContent();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
