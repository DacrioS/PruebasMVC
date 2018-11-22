using Pruebas.Servicios;
using Pruebas.Web.Models;
using System;
using System.Web.Mvc;

namespace Pruebas.Web.Controllers
{
    /// <summary>
    /// Da acceso singleton a la factoría de modelos
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class BaseMvcController : Controller
    {
        private IPruebasServicio gestorPruebas;
        protected IPruebasServicio GestorPruebas
        {
            get { return gestorPruebas; }
        }

        public BaseMvcController(IPruebasServicio gestorPruebas)
        {
            this.gestorPruebas = gestorPruebas;
        }

        /// <summary>
        /// Utilizar para tener en el HTML el valor de la ruta de despliegue (para llamadas a WS)
        /// </summary>
        /// <param name="ctx">El ActionExecutingContext.</param>
        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
            var rutaApp = String.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ApplicationPath)
                    ? String.Empty : (System.Web.HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + '/');
            ViewBag.RutaDespliegue = string.Format("{0}://{1}{2}",
                Request.Url.Scheme, Request.Url.Authority, rutaApp);
        }
    }
}