using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LRezWebAppAdmin.Startup))]
namespace LRezWebAppAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
