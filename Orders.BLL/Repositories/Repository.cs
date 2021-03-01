using Microsoft.EntityFrameworkCore;
using Orders.DAL.Entities;
using Orders.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Orders.BLL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : AuditableEntity
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<TEntity> entities;
        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = dbContext.Set<TEntity>();
        }
        public async void Create(TEntity entity)
        {
            await entities.AddAsync(entity);
        }

        public async void Delete(int id)
        {
            var entity = await FindById(id);
            entities.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await entities.Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> FindById(int id)
        {
            return await entities.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await entities.Where(a=>a.IsDeleted == false).ToListAsync();
        }

        public async Task<TEntity> GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await entities.SingleOrDefaultAsync(predicate);
        }

        public void Update(TEntity entity)
        {
            entities.Update(entity);
        }
    }
}
