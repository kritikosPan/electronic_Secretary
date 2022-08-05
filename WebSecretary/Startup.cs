using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSecretary.Startup))]
namespace WebSecretary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
