using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Common.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : BaseEntity
    {
        private DbContext dbContext;
        private DbSet<TEntity> dbSet;

        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            dbSet.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public async Task<TEntity> GetEntityById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Update(TEntity entity)
        {
            if(entity != null)
            {
                var oldEntity = dbSet.Find(entity.Id);
                if(oldEntity != null)
                {
                    dbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
