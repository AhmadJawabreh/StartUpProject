using Models;
using Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.IManagers
{
    public interface IBookManager
    {
        public Task<List<BookResource>> GetAllAsync();
        public Task<BookResource> GetByIdAsync(long Id);
        public Task<BookResource> InsertAsync(BookModel bookModel);
        public Task<BookResource> UpdateAsync(BookModel bookModel);
        public Task Delete(long Id);
    }
}
