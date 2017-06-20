using AutoMapper;
using Rate.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rate.Repository.Abstract
{
    public interface IModelRepository<TEntity, TModel> where TEntity : class
    {
        IMapper Mapper
        {
            get;
            set;
        }

        IRepository<TEntity> DefaultRepository { get; set; }

        ICollection<TModel> FetchAll();
        int DeleteAll(IEnumerable<TModel> collection);
        List<TModel> FindBy(Expression<Func<TModel, bool>> predicate);
        TModel Add(TModel entity);
        TModel Update(TModel entity);
        bool Delete(TModel entity);
        bool Any(Expression<Func<TModel, bool>> predicate);
    }
}
