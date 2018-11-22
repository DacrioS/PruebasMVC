using Microsoft.Practices.Unity;
using Pruebas.Entidades;
using Pruebas.Servicios;
using Pruebas.Web.App_Start;
using System;

namespace Pruebas.Web.Models
{
    /// <summary>
    /// Contiene los métodos Create y Parse para convertir las entidadas al modelo
    /// esperado por las vistas.
    /// </summary>
    public class ModelFactory
    {
        private static ModelFactory instance;

        /// <summary>
        /// Obtiene la instancia Singleton de la clase ModelFactory.
        /// </summary>
        /// <value>
        /// La ModelFactory.
        /// </value>
        public static ModelFactory Instance
        {
            get
            {
                return instance ?? (instance = new ModelFactory(
                    UnityConfig.GetConfiguredContainer().Resolve<IPruebasServicio>()));
            }
        }

        private IPruebasServicio GestorPruebas { get; set; }

        private ModelFactory(IPruebasServicio gestorPruebas)
        {            
            GestorPruebas = gestorPruebas;
        }

        #region Métodos Create (Entidad a Modelo)
        public ConfiguracionModel Create(Configuracion conf)
        {
            return conf == null ? null : new ConfiguracionModel
            {
                ConfiguracionId = conf.ConfiguracionId,
                Descripcion = conf.Descripcion,
                Valor = conf.Valor
            };
        }

        public UsuarioModel Create(Usuario usuario)
        {
            return usuario == null ? null : new UsuarioModel
            {
                UsuarioId = usuario.UsuarioId,
                Activo = usuario.Activo,
                Login = usuario.Login,
                NombreCompleto = usuario.NombreCompleto,
                Email = usuario.Email,
                UltimoAcceso = usuario.UltimoAcceso.ToString("dd/MM/yyyy HH:mm")
            };
        }
        #endregion

        #region Métodos Parse (Modelo a Entidad)
        public Configuracion Parse(ConfiguracionModel conf)
        {
            return conf == null ? null : new Configuracion
                {
                    ConfiguracionId = conf.ConfiguracionId,
                    Descripcion = conf.Descripcion,
                    Valor = conf.Valor
                };
        }

        public Usuario Parse(UsuarioModel usuario)
        {
            return usuario == null ? null : new Usuario
            {
                UsuarioId = usuario.UsuarioId,
                Activo = usuario.Activo,
                Login = usuario.Login,
                NombreCompleto = usuario.NombreCompleto,
                Email = usuario.Email,
                UltimoAcceso = DateTime.Parse(usuario.UltimoAcceso)
            };
        }
        #endregion
    }
}