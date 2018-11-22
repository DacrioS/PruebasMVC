using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas.Persistencia
{
    public class LocalDBContextFactory : IDbContextFactory<LocalDBPruebasContext>
    {
        public LocalDBPruebasContext Create()
        {
            //Esta factoría, en principio, la utilizaré solo para la generación
            //de scripts SQL con Entity Framework Migrations
            return new LocalDBPruebasContext(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=D:\LocalDB\aspnet-Pruebas.Web-20170207.mdf;Initial Catalog=aspnet-Pruebas.Web-20170207;Integrated Security=True");
        }
    }
}
