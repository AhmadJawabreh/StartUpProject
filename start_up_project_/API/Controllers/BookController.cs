﻿using BusinessLogic;
using Contract.Filters;
using Filters;
using Microsoft.AspNetCore.Mvc;
using Models;
using Resources;
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
        public IActionResult GetAllBooks([FromQuery] BookFilter BookFilter, [FromQuery] Pagination pagination)
        {
            List<BookResource> bookResources = _bookManager.GetAll(BookFilter, pagination.PageNumber, pagination.PageSize);
            return Ok(bookResources);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Details([FromRoute] int Id)
        {
            BookResource bookResource = await _bookManager.GetByIdAsync(Id);
            return Ok(bookResource);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookModel bookModel)
        {
            BookResource bookResource = await _bookManager.InsertAsync(bookModel);
            return Ok(bookResource);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] BookModel bookModel)
        {
            BookResource bookResource = await _bookManager.UpdateAsync(bookModel);
            return Ok(bookResource);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            await _bookManager.Delete(Id);
            return Ok();
        }
    }
}
