using Models;
using Resources;
using System.Collections.Generic;


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
