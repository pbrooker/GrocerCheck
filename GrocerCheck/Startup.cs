using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrocerCheck.Startup))]
namespace GrocerCheck
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
