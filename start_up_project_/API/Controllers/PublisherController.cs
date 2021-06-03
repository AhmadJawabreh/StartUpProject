using API.Repoistories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{

    [Route("api/publisher")]
    public class PublisherController : Controller
    {
      
        private readonly IUnitOfWork _unitOfWork;
       
        public PublisherController(IUnitOfWork unitOfWork) {

            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        [Route("all")]
        public object GetAll() {

            try {

                return _unitOfWork.Publishers.GetAll();

            }catch(Exception error) {

                throw error;
            }

        }


        [HttpGet]
        [Route("details/{id}")]
        public object Details([FromRoute] int id)
        {
            try
            {
                return _unitOfWork.Publishers.GetById(id);
            }
            catch (Exception error) {
                return NotFound();
            }

        }


        [HttpPost]
        [Route("add")]
        public ActionResult Create([FromBody] Publisher publisher)
        {
            try
            {
                _unitOfWork.Publishers.Insert(publisher);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception error)
            {
                throw error;
            }
        }


        [HttpPut]
        [Route("update")]
        public ActionResult Update([FromBody] Publisher publisher)
        {
            try
            {
                _unitOfWork.Publishers.Update(publisher);
                _unitOfWork.Save();

                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                _unitOfWork.Publishers.Delete(id);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception error)
            {
                return NotFound();
            }
        }

    }
}
