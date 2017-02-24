using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ecom45.Startup))]
namespace ecom45
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
