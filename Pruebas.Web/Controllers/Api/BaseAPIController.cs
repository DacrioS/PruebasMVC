using Pruebas.Servicios;
using Pruebas.Web.Models;
using System.Web.Http;

namespace Pruebas.Web.Controllers.API
{
    /// <summary>
    /// Da acceso singleton a la factoría de modelos
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BaseApiController : ApiController
    {
        private IPruebasServicio gestorPruebas;
        private object p;

        protected IPruebasServicio GestorPruebas
        {
            get { return gestorPruebas; }
        }

        public BaseApiController(IPruebasServicio gestorPruebas)
        {
            this.gestorPruebas = gestorPruebas;
        }
    }
}