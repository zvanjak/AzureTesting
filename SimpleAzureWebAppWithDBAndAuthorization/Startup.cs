using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleAzureWebAppWithDBAndAuthorization.Startup))]
namespace SimpleAzureWebAppWithDBAndAuthorization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
