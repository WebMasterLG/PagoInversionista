using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(corretaje.Startup))]
namespace corretaje
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
