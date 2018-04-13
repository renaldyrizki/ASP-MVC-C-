using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab01_151524026_Renaldy.Startup))]
namespace Lab01_151524026_Renaldy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
