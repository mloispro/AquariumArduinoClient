using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AquariumArduinoWeb.Startup))]
namespace AquariumArduinoWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
