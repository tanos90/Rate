using System;
using System.IO;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;
using log4net.Config;
using Rate.App_Start;

namespace Rate
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(httpConfiguration => {

                httpConfiguration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                ConfigureLogger();

                httpConfiguration.MapHttpAttributeRoutes();

            });

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void ConfigureLogger()
        {

            String configFile = ConfigurationManager.AppSettings.Get("log4net.Config");
            if (!string.IsNullOrEmpty(configFile))
            {
                configFile = Environment.ExpandEnvironmentVariables(configFile);
                XmlConfigurator.Configure(new FileInfo(configFile));
            }
            XmlConfigurator.Configure();
        }
    }
}
