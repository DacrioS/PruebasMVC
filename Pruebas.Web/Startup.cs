using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pruebas.Web.Startup))]
namespace Pruebas.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
