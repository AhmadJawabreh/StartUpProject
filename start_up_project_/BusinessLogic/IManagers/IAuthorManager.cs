using Models;
using Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.IManagers
{
    public  interface IAuthorManager
    {     
         List<AuthorResource> GetAll(int PageNumber, int PageSize);
         Task<AuthorResource> GetByIdAsync(long id);
         Task<AuthorResource> InsertAsync(AuthorModel authorModel);
         Task<AuthorResource> UpdateAsync(AuthorModel authorModel);
         Task DeleteAsync(long id);
    }
}
