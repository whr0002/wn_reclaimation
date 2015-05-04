using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WN_Reclaimation.Startup))]
namespace WN_Reclaimation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
