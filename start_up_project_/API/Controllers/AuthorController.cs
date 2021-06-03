using API.Repoistories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{

    [Route("api/author")]
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


       public AuthorController(IUnitOfWork unitOfWork) 
        {
            this._unitOfWork = unitOfWork;
        }


        [Route("all")]
        [HttpGet]
        public object GetAll()
        {
            try
            {
               return  this._unitOfWork.Athuors.GetAll();
            }
            catch (Exception Error) 
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }


        [Route("details/{id}")]
        [HttpGet]
        public object Details([FromRoute] long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return this._unitOfWork.Athuors.GetById(id);
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return  BadRequest();
            }
        }


        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody] Author author)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                this._unitOfWork.Athuors.Insert(author);
                return Ok();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] Author author)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                this._unitOfWork.Athuors.Update(author);
                return Ok();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute] long id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                this._unitOfWork.Athuors.Delete(id);
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
