﻿using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        ICollection<TEntity> GetAll();

        int Count(Expression<Func<TEntity, bool>> spec = null);

        bool Exist(Expression<Func<TEntity, bool>> spec = null);

        TEntity GetByID(object Id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        void SaveChanges();

        void Dispose();
    }
}