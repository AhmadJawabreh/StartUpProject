using Data;
using Entities;
using Filters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repoistories
{

    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookWithAuthorsAndPublisher(Filter filter, long Id);
    }

    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

       
        public override List<Book> GetAll(Filter filter)
        {

            IQueryable<Book> _dbSet = dbSet;

            if (!string.IsNullOrEmpty(filter.BookName))
            {
                _dbSet = _dbSet.Where(item => item.Name == filter.BookName);
            }

            if (filter.Publisher)
            {
                _dbSet = _dbSet.Include(item => item.Publisher);
            }

            if (filter.Authors)
            {
                _dbSet = _dbSet.Include(item => item.Authors);
            }

            List<Book> books = _dbSet.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();

            return books;
        }

        public async Task<Book> GetBookWithAuthorsAndPublisher(Filter filter, long Id)
        {
            IQueryable<Book> _dbSet = dbSet;
            if (filter.Publisher)
            {
                _dbSet = _dbSet.Include(item => item.Publisher);
            }

            if (filter.Authors)
            {
                _dbSet = _dbSet.Include(item => item.Authors);
            }

            return await _dbSet.FirstOrDefaultAsync(item => item.Id == Id);
        }
    }
}
