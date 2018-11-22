using Pruebas.Entidades;
using Pruebas.Repositorio;
using System;
using System.Linq;

namespace Pruebas.Servicios
{
    public static class ExtensorConfiguracion
    {
        public static String ObtenerValorDe<T>(this IRepository<T> repository, string key) where T : Configuracion
        {
            var res = repository.Query().Filter(x => x.Descripcion.Equals(key)).Get().FirstOrDefault();
            return res == null ? null : res.Valor;
        }
    }
}
