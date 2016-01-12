using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MenuManagementMVC.Startup))]
namespace MenuManagementMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
