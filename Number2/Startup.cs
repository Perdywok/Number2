using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Number2.Startup))]
namespace Number2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
