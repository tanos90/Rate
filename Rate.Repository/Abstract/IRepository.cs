using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rate.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        int DeleteAll(IEnumerable<TEntity> collection);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        bool Delete(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
