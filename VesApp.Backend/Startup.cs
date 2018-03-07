using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VesApp.Backend.Startup))]
namespace VesApp.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
