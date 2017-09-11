using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AHProfork.Startup))]
namespace AHProfork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
