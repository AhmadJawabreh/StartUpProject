using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using Resources;
using BusinessLogic.IManagers;
using System.Collections.Generic;

namespace API.Controllers
{

    [Route("Author")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorManager _authorManager;


       public AuthorController(IAuthorManager authorManager) 
       {
            this._authorManager = authorManager;
       }

        [HttpGet]
        public List<AuthorResource> GetAll()
        {
            try
            {
                return this._authorManager.GetAll();
            }
            catch (Exception Error) {
                throw Error;
            }
        }
       
        [HttpGet("{Id}")]
        public AuthorResource Details([FromRoute] long Id)
        {
            try
            {
                return this._authorManager.GetById(Id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpPost]
        public void Add([FromBody] AuthorModel authorModel)
        {
            try
            {
                this._authorManager.Insert(authorModel);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpPut]
        public void Update([FromBody] AuthorModel authorModel)
        {
            try
            {
                this._authorManager.Update(authorModel);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        [HttpDelete("{Id}")]
        public void Delete([FromRoute] long Id)
        {
            try
            {
                this._authorManager.Delete(Id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
