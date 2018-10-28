using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrackerModuleV1._0.Startup))]
namespace TrackerModuleV1._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
