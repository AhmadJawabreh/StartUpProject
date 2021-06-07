using Repoistories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using Resources;

namespace API.Controllers
{

    [Route("book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork) 
        {
            this._unitOfWork = unitOfWork;
        } 


        [HttpGet]
        public object GetAllBooks()
        {
            try
            {
                List<BookResource> BookResourcess = new List<BookResource>();
                IEnumerable<Book> Books = _unitOfWork.Books.GetAll();
                foreach (var Item in Books) {
                    BookResourcess.Add(
                         new BookResource
                             {
                                    Id = Item.Id,
                                    Name = Item.Name,
                                    ReleaseDate = Item.ReleaseDate
                             }        
                        );
                }

                return BookResourcess;
            }
            catch (Exception Error) 
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public object Details([FromRoute] int Id)
        {
            try
            {
                BookResource bookResource = new BookResource();
                Book book =  _unitOfWork.Books.GetById(Id);
                bookResource.Id = bookResource.Id;
                bookResource.Name = book.Name;
                bookResource.ReleaseDate = bookResource.ReleaseDate;
                return bookResource;
              
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookModel bookModel)
        {
            try
            {
                Book book = new Book();
                book.Name = bookModel.Name;
                book.ReleaseDate = bookModel.ReleaseDate;
                book.Authors = bookModel.Auhthors;
                book.PublisherId = bookModel.PublisherId;
                _unitOfWork.Books.Insert(book);
                this._unitOfWork.Save();
                return Ok();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] BookModel bookModel) 
        {
            try
            {
                Book book = _unitOfWork.Books.GetById(bookModel.Id);
                book.Name = bookModel.Name;
                book.ReleaseDate = bookModel.ReleaseDate;
                _unitOfWork.Books.Update(book);
                this._unitOfWork.Save();
                return Ok();
            }
            catch (Exception Error) 
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] int Id) 
        {
            try
            {
                _unitOfWork.Books.Delete(Id);
                this._unitOfWork.Save();
                return Ok();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }
    }
}
