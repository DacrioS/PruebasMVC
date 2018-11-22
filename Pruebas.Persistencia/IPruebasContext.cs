using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pruebas.Entidades;

namespace Pruebas.Persistencia
{
    public interface IPruebasContext : IDbContext
    {
        new IDbSet<T> Set<T>() where T : class;

        //int SaveChanges();
    }
}
