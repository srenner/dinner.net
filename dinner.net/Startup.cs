using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dinner.net.Startup))]
namespace dinner.net
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
