using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DAL
{
    public interface IRepository<TEntity> where TEntity : class {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        void Insert(TEntity punlisher);
        void Update(TEntity punlisher);
        void Delete(long id);
    }
}
