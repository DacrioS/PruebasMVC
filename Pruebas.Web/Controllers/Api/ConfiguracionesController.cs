using Pruebas.Servicios;
using Pruebas.Web.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace Pruebas.Web.Controllers.API
{
    [EnableCors(origins: "http://localhost:55914", headers: "*", methods: "*")]
    public class ConfiguracionesController : BaseApiController
    {
        public ConfiguracionesController(IPruebasServicio gestorPruebas) : base(gestorPruebas) { }

        //private readonly int _pageSize = 5; //tamaño de página por defecto
        /// <summary>
        /// Recupera las configuraciones registradas en el sistema.
        /// </summary>
        /// <param name="pagina">(Opcional)La página.</param>
        /// <param name="cantidad">(Opcional)La cantidad de elementos a recuperar.</param>
        /// <returns>Colección de configuraciones registradas.</returns>
        //public HttpResponseMessage Get(int pagina = 1, int cantidad = 0)
        //{
        //    if (cantidad == 0)
        //        cantidad = _pageSize;

        //    //Func<IQueryable<Configuracion>, IOrderedQueryable<Configuracion>> orderBy = null;

        //    int totalRegistros;
        //    var configuraciones = GestorPruebas.ObtenerConfiguraciones(pagina, _pageSize, out totalRegistros)
        //        .Select(ModelFactory.Instance.Create).OrderBy(r => r.NodoId).ToList();

        //    int totalPaginas = (int)Math.Ceiling((double)totalRegistros / cantidad);
        //    var paginas = new
        //    {
        //        TotalRegistros = totalRegistros,
        //        totalPaginas = totalPaginas,
        //        PaginaAnterior = pagina > 1 ? ModelFactory.UrlHelper.Link("Configuraciones", new { pagina = pagina - 1 }) : null,
        //        PaginaSiguiente = pagina < totalPaginas ? ModelFactory.UrlHelper.Link("Configuraciones", new { pagina = pagina + 1 }) : null
        //    };
        //    return Request.CreateResponse(HttpStatusCode.OK, new { Paginas = paginas, Datos = configuraciones });
        //}
        [HttpGet]
        [EnableQuery]
        public HttpResponseMessage Get()
        {
            //if (Usuario == null)
            //    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Non ten permisos para realizala acción");

            return Request.CreateResponse(HttpStatusCode.OK, GestorPruebas.ObtenerConfiguraciones()
                    .Select(ModelFactory.Instance.Create));
        }

        /// <summary>
        /// Recupera una configuración registrada en el sistema
        /// </summary>
        /// <param name="id">Id de la configuración a recuperar</param>
        /// <returns>Datos de la configuración</returns>
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            //if (Usuario == null)
            //    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Non ten permisos para realizala acción");

            var conf = GestorPruebas.ObtenerConfiguracion(id);
            if (conf == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Configuracion non atopado");
            return Request.CreateResponse(HttpStatusCode.OK, ModelFactory.Instance.Create(conf));
        }

        /// <summary>
        /// Crea la configuración especificada
        /// </summary>
        /// <param name="configuracion">La configuracion.</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ConfiguracionModel configuracion)
        {
            try
            {
                var conf = ModelFactory.Instance.Parse(configuracion);
                conf = GestorPruebas.RegistrarConfiguracion(conf);

                return Request.CreateResponse(HttpStatusCode.Created,
                    ModelFactory.Instance.Create(conf));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Actualiza la configuración con el identificador especificado.
        /// </summary>
        /// <param name="id">El identificador.</param>
        /// <param name="configuracion">La configuración.</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] ConfiguracionModel configuracion)
        {
            try
            {
                //if (!Usuario.Elementos.Contains(Elemento.PLACEHOLDER))
                //    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Sin permiso.");

                var conf = ModelFactory.Instance.Parse(configuracion);
                var encontrado = GestorPruebas.ModificarConfiguracion(conf);
                return encontrado
                    ? Request.CreateResponse(HttpStatusCode.OK)
                    : Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Elimina la configuración con el identificador especificado.
        /// </summary>
        /// <param name="id">El identificador de la configuración a borrar.</param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                //if (!Usuario.Elementos.Contains(Elemento.PLACEHOLDER))
                //    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Sin permiso.");

                var encontrado = GestorPruebas.EliminarConfiguracion(id);
                return encontrado
                    ? Request.CreateResponse(HttpStatusCode.OK)
                    : Request.CreateResponse(HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}