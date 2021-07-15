using Data;
using Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repoistories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        private DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual List<TEntity> GetAll(Filter filter)
        {
            if (filter.PageNumber == null && filter.PageSize == null)
                return _dbSet.ToList();

            return _dbSet.Skip((int)((filter.PageNumber - 1) * filter.PageSize)).Take((int)filter.PageSize).ToList();
        }

        public async Task<TEntity> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public TEntity FirstOrDefalut(Func<TEntity, bool> condition)
        {
            return _dbSet.Where(condition).FirstOrDefault();
        }
    }
}
