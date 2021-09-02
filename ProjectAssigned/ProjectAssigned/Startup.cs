using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectAssigned.Startup))]
namespace ProjectAssigned
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
