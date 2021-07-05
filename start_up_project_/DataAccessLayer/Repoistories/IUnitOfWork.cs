using System.Threading.Tasks;
using Entities;

namespace Repoistories
{
    public interface IUnitOfWork
    {
        public IRepository<Publisher> Publishers { get; }

        public IRepository<Author> Athuors { get; }

        public Task Save();
    }
}
