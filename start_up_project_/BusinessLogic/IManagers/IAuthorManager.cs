using Models;
using Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.IManagers
{
    public  interface IAuthorManager
    {
        public Task<List<AuthorResource>> GetAllAsync();
        public Task<AuthorResource> GetByIdAsync(long id);
        public Task<AuthorResource> InsertAsync(AuthorModel authorModel);
        public Task<AuthorResource> UpdateAsync(AuthorModel authorModel);
        public Task DeleteAsync(long id);
    }
}
