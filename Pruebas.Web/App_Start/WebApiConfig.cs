using System.Web.Http;

namespace Pruebas.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.EnableCors();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
