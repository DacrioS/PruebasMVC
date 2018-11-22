using Pruebas.Entidades;
using Pruebas.Repositorio;
using System.Linq;

namespace Pruebas.Servicios
{
    public static class ExtensionUsuario
    {
        public static T ObtenerPorLogin<T>(this IRepository<T> repository, string login) where T : Usuario
        {
            return repository.Query().Filter(x => x.Login.Equals(login)).Get().FirstOrDefault();
        }
    }
}
