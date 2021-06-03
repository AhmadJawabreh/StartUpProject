using API.Repoistories;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{

    [Route("api/auther")]
    public class AutherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


       public AutherController(IUnitOfWork unitOfWork) {

            this._unitOfWork = unitOfWork;

       }


        [Route("all")]
        [HttpGet]
        public object GetAll() {
            try
            {
               return  this._unitOfWork.Athuers.GetAll();
            }
            catch (Exception Error) {
                throw Error;
            }
        }


        [Route("details/{id}")]
        [HttpGet]
        public object Details([FromRoute] long id) {
            try
            {
                return this._unitOfWork.Athuers.GetById(id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }


        [Route("add")]
        [HttpPost]

        public void Add([FromBody] Auther auther)
        {
            try
            {
                 this._unitOfWork.Athuers.Insert(auther);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [Route("update")]
        [HttpPut]
        public void Update([FromBody] Auther auther)
        {
            try
            {
                this._unitOfWork.Athuers.Update(auther);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public void Delete([FromRoute] long id)
        {
            try
            {
                this._unitOfWork.Athuers.Delete(id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

    }
}
