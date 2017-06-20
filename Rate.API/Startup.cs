using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Rate.Startup))]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Rate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
