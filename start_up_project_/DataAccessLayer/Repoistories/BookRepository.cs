namespace Repoistories
{
    using Data;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookWithAuthorsAndPublisher(bool authors, bool publisher, long Id);
    }

    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Book> GetBookWithAuthorsAndPublisher(bool authors, bool publisher, long Id)
        {


            if (publisher && authors)
            {
                return await dbSet.Include(item => item.Authors).Include(item => item.Publisher).FirstOrDefaultAsync(item => item.Id == Id);
            }

            if (authors)
            {
                return await dbSet.Include(item => item.Authors).FirstOrDefaultAsync(item => item.Id == Id);
            }

            if (publisher)
            {
                return await dbSet.Include(item => item.Publisher).FirstOrDefaultAsync(item => item.Id == Id);
            }

            return await dbSet.FirstOrDefaultAsync(item => item.Id == Id);
        }
    }
}
