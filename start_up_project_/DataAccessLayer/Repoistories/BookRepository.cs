namespace Repoistories
{
    using Data;
    using Entities;
    using Filters;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookWithAuthorsAndPublisher(BookFilter bookFilter, long Id);
    }

    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Book> GetBookWithAuthorsAndPublisher(BookFilter bookFilter, long Id)
        {
            IQueryable<Book> _dbSet = dbSet;
            if (bookFilter.Publisher)
            {
                _dbSet = _dbSet.Include(item => item.Publisher);
            }

            if (bookFilter.Authors)
            {
                _dbSet = _dbSet.Include(item => item.Authors);
            }

            return await _dbSet.FirstOrDefaultAsync(item => item.Id == Id);
        }
    }
}
