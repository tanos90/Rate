using AutoMapper;
using Rate.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Rate.Repository.Base
{
    public abstract class ModelServiceBase<TDbContext, TEntity, TModel> : IModelRepository<TEntity, TModel>
           where TEntity : class
           where TModel : class
           where TDbContext : DbContext
    {
        public IMapper Mapper { get; set; }

        public ServiceBase<TDbContext, TEntity> ServiceBase { get; set; }


        public IRepository<TEntity> DefaultRepository
        {
            get;
            set;
        }

        public ModelServiceBase(TDbContext context, Action<IMapperConfigurationExpression> initMappers)
            : this(new ServiceBase<TDbContext, TEntity>(context))
        {
            this.Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<TEntity, TModel>();
                config.CreateMap<TModel, TEntity>();
                initMappers.Invoke(config);
            }).CreateMapper();
        }

        public ModelServiceBase(ServiceBase<TDbContext, TEntity> service)
        {

            this.ServiceBase = service;
            this.DefaultRepository = this.ServiceBase.DefaultRepository;
        }

        public ICollection<TModel> FetchAll()
        {
            var entities = ServiceBase.GetAll();
            return this.Mapper.Map<ICollection<TModel>>(entities.ToList());
        }

        public int DeleteAll(IEnumerable<TModel> collection)
        {
            var entitiesToDelete = this.Mapper.Map<ICollection<TEntity>>(collection);
            return ServiceBase.DeleteAll(entitiesToDelete);
        }

        public List<TModel> FindBy(Expression<Func<TModel, bool>> predicate)
        {
            var entities = ServiceBase.FindBy(this.Mapper.Map<Expression<Func<TEntity, bool>>>(predicate));
            return this.Mapper.Map<List<TModel>>(entities.ToList());
        }

        public TModel Add(TModel model)
        {
            TEntity entityToSave = this.Mapper.Map<TEntity>(model);
            entityToSave = ServiceBase.Add(entityToSave);
            return Mapper.Map<TModel>(entityToSave);
        }

        public bool Any(Expression<Func<TModel, bool>> predicate)
        {
            return ServiceBase.Any(this.Mapper.Map<Expression<Func<TEntity, bool>>>(predicate));
        }

        public TModel Update(TModel model)
        {
            TEntity entityToUpdate = this.Mapper.Map<TEntity>(model);
            entityToUpdate = ServiceBase.Update(entityToUpdate);
            return Mapper.Map<TModel>(entityToUpdate);
        }

        public bool Delete(TModel model)
        {
            TEntity entityToDelete = this.Mapper.Map<TEntity>(model);
            return ServiceBase.Delete(entityToDelete);
        }
    }
}
