using API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API.DAL
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        private readonly DbSet<TEntity> dbSet;


        public BaseRepository(ApplicationDbContext context) {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void Delete(long id)
        {
            TEntity entity = this.dbSet.Find(id);
            this.dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.dbSet.ToList();
        }

        public TEntity GetById(long id)
        {
            return this.dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.dbSet.Update(entity);
        }
    }
}
