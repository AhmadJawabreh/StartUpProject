using Models;
using Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.IManagers
{
    public interface IBookManager
    {
         Task<List<BookResource>> GetAllAsync();
         Task<BookResource> GetByIdAsync(long Id);
         Task<BookResource> InsertAsync(BookModel bookModel);
         Task<BookResource> UpdateAsync(BookModel bookModel);
         Task Delete(long Id);
    }
}
