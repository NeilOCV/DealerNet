using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DealerNetOrderingSystem.Startup))]
namespace DealerNetOrderingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
