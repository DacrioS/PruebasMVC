using Pruebas.Entidades;
using Pruebas.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pruebas.Servicios
{
    public class PruebasServicio : ServicioBase, IPruebasServicio
    {
        private Usuario usuario;

        public PruebasServicio(Usuario usuario, IUnitOfWork uow) : base(uow)
        {
            if (usuario == null) //Para verificaciones de permisos
                throw new Exception("É necesario que o usuario teña valor");
            this.usuario = usuario;
        }

        #region Métodos sobre Configuraciones
        public Configuracion ObtenerConfiguracion(int confId)
        {
            return ConfiguracionRepositorio.Query()
                .Filter(c => c.ConfiguracionId == confId).Get().FirstOrDefault();
        }

        public IList<Configuracion> ObtenerConfiguraciones()
        {
            return ConfiguracionRepositorio.Query().Get().ToList();
        }

        public Configuracion RegistrarConfiguracion(Configuracion conf)
        {
            ConfiguracionRepositorio.Insert(conf);
            UoW.Save();
            return conf;
        }

        public bool ModificarConfiguracion(Configuracion confMod)
        {
            var confDb = ObtenerConfiguracion(confMod.ConfiguracionId);
            if (confDb != null)
            {
                //Cambios y comprobaciones/registro de cambios:
                confDb.Descripcion = confMod.Descripcion;
                confDb.Valor = confMod.Valor;

                ConfiguracionRepositorio.Update(confDb);
                UoW.Save();
            }
            return confDb != null;
        }

        public bool EliminarConfiguracion(int confId)
        {
            var confDb = ObtenerConfiguracion(confId);
            var encontrado = confDb != null;
            if (encontrado)
            {
                //Cualquier comprobación o registro de cambios debería realizarse aquí
                ConfiguracionRepositorio.Delete(confDb);
                UoW.Save();
            }
            return encontrado;
        }
        #endregion

        #region Métodos sobre Usuarios
        public Usuario ObtenerUsuario(int usuarioId)
        {
            return UsuarioRepositorio.Query()
                .Filter(u => u.UsuarioId == usuarioId).Get().FirstOrDefault();
        }

        public IList<Usuario> ObtenerUsuarios()
        {
            return UsuarioRepositorio.Query().Get().ToList();
        }

        /// <summary>
        /// Obtiene el listado de usuarios permitiendo utilizar paginación y filtrado.
        /// </summary>
        /// <param name="totalRegistros">Parámetro de salida por el que se obtendrá el total de usuarios.</param>
        /// <param name="pagina">El número de página a recuperar o null si se desean todos.</param>
        /// <param name="cantidad">La cantidad de usuarios por página o null si se desean todos.</param>
        /// <param name="filter">Los filtros a aplicar.</param>
        /// <returns>Según página sea null o no, devolverá una página concreta o
        /// el listado completo de recursos que cumplen los filtros.</returns>
        public IList<Usuario> BuscarUsuario(out int totalRegistros, int? pagina, int? cantidad,
            IList<Expression<Func<Usuario, bool>>> filter,
            Func<IQueryable<Usuario>, IOrderedQueryable<Usuario>> orderBy)
        {
            cantidad = cantidad.HasValue ? cantidad.Value : 30;
            var query = UsuarioRepositorio
                .Query();
            if (filter != null && filter.Count > 0)
                query.Filter(filter);

            // Para incluir relaciones (si usamos LazyLoading)
            /* query
                .Include(u => u.Propiedad);*/

            if (orderBy != null)
                query.OrderBy(orderBy);
            else
                query.OrderBy(q => q.OrderBy(u => u.UltimoAcceso));

            if (pagina.HasValue)
                return query.GetPage(pagina.Value, cantidad.Value, out totalRegistros).ToList();
            var result = query.Get().ToList();
            totalRegistros = result.Count();
            return result;
        }
        #endregion
    }
}