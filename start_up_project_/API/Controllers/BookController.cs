using BusinessLogic.IManagers;
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
        public async Task<List<BookResource>> GetAllBooks()
        {
            try
            {
                return await _bookManager.GetAllAsync();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpGet("{Id}")]
        public async Task<object> Details([FromRoute] int Id)
        {
            try
            {
                return await _bookManager.GetByIdAsync(Id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpPost]
        public async Task<BookResource> Create([FromBody] BookModel bookModel)
        {
            try
            {
                return await _bookManager.InsertAsync(bookModel);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpPut]
        public async Task<BookResource> Update([FromBody] BookModel bookModel)
        {
            try
            {
                return await _bookManager.UpdateAsync(bookModel);
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
                await _bookManager.Delete(Id);
                return NoContent();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
