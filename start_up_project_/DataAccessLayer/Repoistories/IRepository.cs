using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repoistories
{
    public interface IRepository<TEntity> where TEntity : class {
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity> GetById(long id);
        public Task<TEntity> Insert(TEntity entity);
        public TEntity Update(TEntity entity);
        public Task Delete(long id);
    }
}
