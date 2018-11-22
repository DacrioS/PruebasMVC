using System.Web.Mvc;

namespace Pruebas.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Esta es la aplicación de Demo y Pruebas con MVC.";

            return View();
        }
    }
}