using Models;
using Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.IManagers
{
    public  interface IAuthorManager
    {
         Task<List<AuthorResource>> GetAllAsync();
         Task<AuthorResource> GetByIdAsync(long id);
         Task<AuthorResource> InsertAsync(AuthorModel authorModel);
         Task<AuthorResource> UpdateAsync(AuthorModel authorModel);
         Task DeleteAsync(long id);
    }
}
