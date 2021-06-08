using Models;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IManagers
{
    public  interface IAuthorManager
    {
        public List<AuthorResource> GetAll();
        public AuthorResource GetById(long id);
        public void Insert(AuthorModel authorModel);
        public void Update(AuthorModel authorModel);
        public void Delete(long id);
    }
}
