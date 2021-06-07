using Repoistories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using Resources;
using System.Collections.Generic;

namespace API.Controllers
{

    [Route("author")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


       public AuthorController(IUnitOfWork unitOfWork) 
       {
            this._unitOfWork = unitOfWork;
       }

        [HttpGet]
        public object GetAll()
        {
            try
            {
                List<AuthorResource> AuthorResourcess = new List<AuthorResource>();
                IEnumerable<Author> Authors =   this._unitOfWork.Athuors.GetAll();

                foreach (var Author in Authors) 
                {
                    AuthorResourcess.Add(
                        new AuthorResource 
                        { 
                            Id = Author.Id,
                            Email = Author.Email,
                            FullName = Author.Name,
                            DateOfBirth = Author.DateOfBirth
                        
                        }
                      );
                }
                return AuthorResourcess;

            }
            catch (Exception Error) 
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }
       
        [HttpGet("{id}")]
        public object Details([FromRoute] long id)
        {
            try
            {
                AuthorResource authorResource = new AuthorResource();
                Author author = this._unitOfWork.Athuors.GetById(id);
                authorResource.Id = author.Id;
                authorResource.FullName = author.Name;
                authorResource.Email = author.Email;
                authorResource.DateOfBirth = author.DateOfBirth;
                return authorResource;
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return  BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] AuthorModel authorModel)
        {
            try
            {
                Author author = new Author();
                author.Email = authorModel.Email;
                author.DateOfBirth = authorModel.DateOfBirth;
                author.Name = authorModel.FirstName.Trim() + authorModel.LastName.Trim();
                this._unitOfWork.Athuors.Insert(author);
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
        public IActionResult Update([FromBody] AuthorModel AuthorModel)
        {
            try
            {
                Author Author = _unitOfWork.Athuors.GetById(AuthorModel.Id);
                Author.Email = AuthorModel.Email ?? "";
                Author.DateOfBirth = AuthorModel.DateOfBirth;
                Author.Name = AuthorModel.FirstName.Trim() + AuthorModel.LastName.Trim();
                this._unitOfWork.Athuors.Update(Author);
                this._unitOfWork.Save();
                return Ok();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            try
            {
                this._unitOfWork.Athuors.Delete(id);
                this._unitOfWork.Save();
                return Ok();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return NotFound();
            }
        }
    }
}
