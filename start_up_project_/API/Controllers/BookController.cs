using BusinessLogic.IManagers;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{

    [Route("Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookManager _bookManager;

        public BookController(IBookManager bookManager)
        {
            this._bookManager = bookManager;
        }

        [HttpGet]
        public IActionResult GetAllBooks([FromQuery] BookFilter BookFilter,int PageNumber = 1, int PageSize = 15)
        {
            try
            {
                List<BookResource> bookResources =  _bookManager.GetAll(BookFilter, PageNumber, PageSize);
                return Ok(bookResources);
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
                BookResource bookResource = await _bookManager.GetByIdAsync(Id);
                return Ok(bookResource);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookModel bookModel)
        {
            try
            {
                BookResource bookResource = await _bookManager.InsertAsync(bookModel);
                return Ok(bookResource);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BookModel bookModel)
        {
            try
            {
                BookResource bookResource = await _bookManager.UpdateAsync(bookModel);
                return Ok(bookResource);
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
                await _bookManager.Delete(Id);
                return Ok();
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }
    }
}
