using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pruebas.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static UnityContainer container = new UnityContainer();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register); //Routing WebAPI
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes); //Routing MVC@
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
