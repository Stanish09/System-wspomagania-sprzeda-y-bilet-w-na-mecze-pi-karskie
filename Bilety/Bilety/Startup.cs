using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bilety.Startup))]
namespace Bilety
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
