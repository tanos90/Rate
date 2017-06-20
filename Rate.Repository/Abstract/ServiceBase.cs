using Rate.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Rate.Repository.Abstract
{
    public class ServiceBase<TDbContext, TEntity> : IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected TDbContext Context
        {
            get;
        }

        public IRepository<TEntity> DefaultRepository
        {
            get;
        }

        public ServiceBase(TDbContext context)
        {

            this.DefaultRepository = new GenericRepository<TDbContext, TEntity>(context);
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DefaultRepository.FindBy(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.DefaultRepository.GetAll();
        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                return this.DefaultRepository.Add(entity);
            }
            catch (DbEntityValidationException e)
            {
                var message = new StringBuilder();
                e.EntityValidationErrors.ToList().ForEach(err =>
                {
                    err.ValidationErrors.ToList().ForEach(validation =>
                    {
                        message.Append(validation.ErrorMessage);
                    });
                });
                throw new Exception(message.ToString());
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Delete(TEntity entity)
        {
            return this.DefaultRepository.Delete(entity);
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                this.DefaultRepository.Update(entity);
                return entity;
            }
            catch (DbEntityValidationException e)
            {
                var message = new StringBuilder();
                e.EntityValidationErrors.ToList().ForEach(err =>
                {
                    err.ValidationErrors.ToList().ForEach(validation =>
                    {
                        message.Append(validation.ErrorMessage);
                    });
                });
                throw new Exception(message.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int DeleteAll(IEnumerable<TEntity> collection)
        {
            return this.DefaultRepository.DeleteAll(collection);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DefaultRepository.Any(predicate);
        }

        public TDbContext GetContext()
        {
            return this.Context;
        }
    }
}
