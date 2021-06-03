﻿using API.Repoistories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{

    [Route("api/publisher")]
    public class PublisherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public PublisherController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("all")]
        public object GetAll() 
        {
            try {

                return _unitOfWork.Publishers.GetAll();

            }catch(Exception Error) {

                Console.WriteLine(Error.ToString());
                return NotFound();
            }
        }


        [HttpGet]
        [Route("details/{id}")]
        public object Details([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                return _unitOfWork.Publishers.GetById(id);
            }
            catch (Exception Error) {
                Console.WriteLine(Error.ToString());
                return NotFound();
            }
        }


        [HttpPost]
        [Route("add")]
        public ActionResult Create([FromBody] Publisher publisher)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    return BadRequest();
                }
                _unitOfWork.Publishers.Insert(publisher);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("update")]
        public ActionResult Update([FromBody] Publisher publisher)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                _unitOfWork.Publishers.Update(publisher);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.ToString());
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                _unitOfWork.Publishers.Delete(id);
                _unitOfWork.Save();
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
