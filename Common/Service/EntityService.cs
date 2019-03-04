using Common.GenericRepository;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Service
{
    public class EntityService<TEntity> : IEntityService<TEntity>
        where TEntity : class
    {
        #region properties

        private const string ParamNull = "Entity input cant null";

        private readonly IGenericRepository<TEntity> _repository;

        #endregion properties

        #region constructor

        public EntityService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        #endregion constructor

        #region method

        public int Count(Expression<Func<TEntity, bool>> spec = null)
        {
            return _repository.Count(spec);
        }

        public void Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(ParamNull);
            }
            _repository.Insert(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(ParamNull);
            }
            _repository.Delete(entity);
        }

        public bool Exist(Expression<Func<TEntity, bool>> spec = null)
        {
            return _repository.Exist(spec);
        }

        public TEntity Find(object id)
        {
            return _repository.GetByID(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<TEntity> GetAllIncluing(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            return _repository.Get(filter, orderBy, includeProperties);
        }

        public void Update(TEntity entity, object id)
        {
            _repository.Update(entity, id);
        }

        #endregion method
    }
}