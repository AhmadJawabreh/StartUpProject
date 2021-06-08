using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using Resources;
using BusinessLogic.IManagers;

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
        public List<BookResource> GetAllBooks()
        {
            try
            {
                return _bookManager.GetAll() ;
            }
            catch (Exception Error) 
            {
                throw Error;
            }
        }

        [HttpGet("{Id}")]
        public object Details([FromRoute] int Id)
        {
            try
            {
                return _bookManager.GetById(Id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpPost]
        public void Create([FromBody] BookModel bookModel)
        {
            try
            {
                _bookManager.Insert(bookModel);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpPut]
        public void Update([FromBody] BookModel bookModel) 
        {
            try
            {
                _bookManager.Update(bookModel);
            }
            catch (Exception Error) 
            {
                throw Error;
            }

        
        }

        [HttpDelete("{Id}")]
        public void Delete([FromRoute] int Id) 
        {
            try
            {
                 _bookManager.Delete(Id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
