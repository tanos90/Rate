using AutoMapper;
using Microsoft.Practices.Unity;
using Rate.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity.WebApi;
using Rate.Mapping;
using Rate.Services.Concrete;

namespace Rate.App_Start
{

    public static class UnityConfig
    {
        private readonly static Action<IMapperConfigurationExpression> _mapperConfiguration;

        private readonly static string _dataAccessAPI = ConfigurationManager.AppSettings["DataAccessAPI"];

        static UnityConfig()
        {
            _mapperConfiguration = (mapper) => MappingConfigurations.Init(mapper);
        }
        public static void RegisterComponents()
        {

            var container = new UnityContainer();

            var context = new RateflixContext();

            IFlickAPI flickAPI = new TMDBAdapter();

            var reviewService = new ReviewService(context, _mapperConfiguration);
            var flickService = new FlickService(context, _mapperConfiguration, flickAPI);

            container.RegisterInstance<IReviewService>(reviewService);
            container.RegisterInstance<IFlickService>(flickService);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}