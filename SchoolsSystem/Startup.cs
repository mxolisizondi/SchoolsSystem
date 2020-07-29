using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolsSystem.Startup))]
namespace SchoolsSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
