using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OtakuClub.Startup))]
namespace OtakuClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
