using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Rate.Repository.Abstract;


namespace Rate.Repository.Concrete
{
    public class GenericRepository<TContext, TEntity> :
        IRepository<TEntity>,
        IDisposable
        where TEntity : class
        where TContext : DbContext 
    {
        private bool _disposed;
        protected TContext DbContext;
        protected DbSet<TEntity> Collection;

        public GenericRepository(TContext context)
        {
            DbContext = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = this.DbContext.Set<TEntity>().Where(predicate);
            return query;
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Any(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            var entry = DbContext.Entry(entity);
            entry.State = EntityState.Added;
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public bool Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            var entry = DbContext.Entry(entity);
            entry.State = EntityState.Deleted;
            return DbContext.SaveChanges() > 0;
        }

        public int DeleteAll(IEnumerable<TEntity> collection)
        {
            DbContext.Set<TEntity>().RemoveRange(collection);
            return DbContext.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            var entry = DbContext.Entry(entity);
            entry.State = EntityState.Modified;
            DbContext.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            if (_disposed) return;
            DbContext.Dispose();
            _disposed = true;
        }
    }
}
