using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Taxi_Monitering.Startup))]
namespace Taxi_Monitering
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
