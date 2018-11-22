using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;

namespace Pruebas.Persistencia
{
    public class LocalDBEF6CodeConfig : DbConfiguration
    {
        public LocalDBEF6CodeConfig()
        {
            SetDefaultConnectionFactory(new LocalDBConnectionFactory());
            SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
        }
    }

    internal class LocalDBConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            return new SqlConnection(nameOrConnectionString);

        }
    }
}
