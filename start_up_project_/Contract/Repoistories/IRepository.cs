using Entities;
using System.Collections.Generic;

namespace Repoistories
{
    public interface IRepository<TEntity> where TEntity : class {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(long id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(long id);
    }
}
