using Entities;

namespace Repoistories
{
    public interface IUnitOfWork
    {
        IRepository<Publisher> Publishers { get; }

        IRepository<Author> Athuors { get; }

        IRepository<Book> Books { get; }
        void Save();
    }
}
