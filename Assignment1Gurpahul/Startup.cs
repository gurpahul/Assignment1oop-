using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment1Gurpahul.Startup))]
namespace Assignment1Gurpahul
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
