using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShipbuildingRollingWeb.Startup))]
namespace ShipbuildingRollingWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
