using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RimshotBackend.Startup))]

namespace RimshotBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}