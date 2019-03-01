using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Service
{
    public interface IEntityService<TEntity>
            where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity Find(object id);

        IEnumerable<TEntity> GetAllIncluing(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        bool Exist(Expression<Func<TEntity, bool>> spec = null);

        int Count(Expression<Func<TEntity, bool>> spec = null);

        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}