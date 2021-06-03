using API.DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repoistories
{
    public interface IUnitOfWork
    {
        IRepository<Publisher> Publishers { get; }

        IRepository<Auther> Athuers { get; }

        IRepository<Book> Books { get; }
        void Save();
    }
}
