using Pruebas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pruebas.Servicios
{
    public interface IPruebasServicio
    {
        //Métodos sobre Configuraciones
        Configuracion ObtenerConfiguracion(int confId);
        IList<Configuracion> ObtenerConfiguraciones();
        Configuracion RegistrarConfiguracion(Configuracion conf);
        bool ModificarConfiguracion(Configuracion confMod);
        bool EliminarConfiguracion(int confId);

        //Métodos sobre Usuarios
        Usuario ObtenerUsuario(int usuarioId);
        IList<Usuario> ObtenerUsuarios();
        IList<Usuario> BuscarUsuario(out int totalRegistros, int? pagina, int? cantidad,
            IList<Expression<Func<Usuario, bool>>> filter,
            Func<IQueryable<Usuario>, IOrderedQueryable<Usuario>> orderBy);
    }
}
