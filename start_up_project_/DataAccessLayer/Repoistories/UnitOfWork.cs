using Data;
using Entities;
using System.Threading.Tasks;

namespace Repoistories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<Publisher> _publishers;

        public IBookRepository _books;

        public IRepository<Author> _authors;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IRepository<Publisher> Publishers
        {
            get
            {
                return _publishers ?? (_publishers = new BaseRepository<Publisher>(_context));
            }
        }

        public IBookRepository Books
        {
            get
            {
                return _books ?? (_books = new BookRepository(_context));
            }
        }

        public IRepository<Author> Athuors
        {
            get
            {
                return _authors ?? (_authors = new BaseRepository<Author>(_context));
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
