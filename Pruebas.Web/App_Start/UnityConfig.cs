using Microsoft.Practices.Unity;
using Pruebas.Persistencia;
using Pruebas.Repositorio;
using Pruebas.Servicios;
using Pruebas.Web.Models;
using System;

namespace Pruebas.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // Register your types here
            IDbContext pruebasContext = new LocalDBPruebasContext("DefaultConnection");
            container
                .RegisterInstance(pruebasContext) //Singleton gestionado por Unity
                .RegisterType<IUnitOfWork, UnitOfWork>()
                .RegisterType<IPruebasServicio, PruebasServicio>();
        }
    }
}
