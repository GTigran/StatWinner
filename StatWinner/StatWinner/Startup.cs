using AspNet.Identity.MongoDB.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StatWinner.Startup))]
namespace StatWinner
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AuthStartup.ConfigureAuth(app);

        }
    }
}
