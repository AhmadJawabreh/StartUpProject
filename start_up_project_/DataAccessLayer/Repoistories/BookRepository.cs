using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repoistories
{

    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookWithAuthorsAndPublisher(long Id);
    }

    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Book> GetBookWithAuthorsAndPublisher(long Id)
        {
            return await dbSet.Include(item => item.Publisher).Include(item => item.Authors).FirstOrDefaultAsync(item => item.Id == Id);
        }
    }
}