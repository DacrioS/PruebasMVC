using Pruebas.Entidades;
using Pruebas.Servicios;
using Pruebas.Web.Models;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Pruebas.Web.Controllers
{
    public class ConfiguracionController : BaseMvcController
    {
        public ConfiguracionController(IPruebasServicio gestorPruebas)
            : base(gestorPruebas) { }
        
        /// <summary>
        /// Página inicial de Configuraciones.
        /// </summary>
        /// <returns>Listado de Configuraciones y enlaces de gestión.</returns>
        public ActionResult Index()
        {
            return View(GestorPruebas.ObtenerConfiguraciones()
                .Select(ModelFactory.Instance.Create).ToList());
        }

        /// <summary>
        /// Página inicial de Configuraciones por WebAPI.
        /// </summary>
        /// <returns>Listado y acciones via WebAPI para consultar y gestionar Configuraciones.</returns>
        public ActionResult IndexAPI()
        {
            return View();
        }

        // GET: Configuraciones/Detailles/id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Configuracion configuracion = GestorPruebas.ObtenerConfiguracion(id.Value);
            if (configuracion == null)
            {
                return HttpNotFound();
            }
            return View(ModelFactory.Instance.Create(configuracion));
        }

        // GET: Configuracions/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Configuracions/Create
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConfiguracionId,Descripcion,Valor")] ConfiguracionModel configuracion)
        {
            if (ModelState.IsValid)
            {
                GestorPruebas.RegistrarConfiguracion(ModelFactory.Instance.Parse(configuracion));
                return RedirectToAction("Index");
            }
            return View(configuracion);
        }

        // GET: Configuracions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Configuracion configuracion = GestorPruebas.ObtenerConfiguracion(id.Value);
             return configuracion == null ? (ActionResult)HttpNotFound()
                : View(ModelFactory.Instance.Create(configuracion));
        }

        // POST: Configuracions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConfiguracionId,Descripcion,Valor")] ConfiguracionModel configuracion)
        {
            if (ModelState.IsValid)
            {
                var conf = ModelFactory.Instance.Parse(configuracion);
                GestorPruebas.ModificarConfiguracion(conf);
                return RedirectToAction("Index");
            }
            //Si el modelo no es válido no se realiza ninguna operación sobre ConfiguracionModel
            return View(configuracion);
        }

        // GET: Configuracions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Configuracion configuracion = GestorPruebas.ObtenerConfiguracion(id.Value);
            if (configuracion == null)
            {
                return HttpNotFound();
            }
            return View(ModelFactory.Instance.Create(configuracion));
        }

        // POST: Configuracions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GestorPruebas.EliminarConfiguracion(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
