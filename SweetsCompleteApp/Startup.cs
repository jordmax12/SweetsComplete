using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SweetsCompleteApp.Startup))]
namespace SweetsCompleteApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
