using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Repoistories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<TEntity> dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task Delete(long id)
        {
            TEntity entity = await this.dbSet.FindAsync(id);
            this.dbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(long id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await this.dbSet.AddAsync(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            this.dbSet.Update(entity);
            return entity;
        }
    }
}
