using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pruebas.Web.Controllers;
using System.Web.Mvc;

namespace Pruebas.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Esta es la aplicación de Demo y Pruebas con MVC.", result.ViewBag.Message);
        }
    }
}
