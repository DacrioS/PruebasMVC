using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Oracle.ManagedDataAccess.EntityFramework;
using Oracle.ManagedDataAccess.Client;

namespace Pruebas.Persistencia
{
    public class OracleEF6CodeConfig : DbConfiguration
    {
        public OracleEF6CodeConfig()
        {
            SetDefaultConnectionFactory(new OracleConnectionFactory());
            SetProviderServices("Oracle.ManagedDataAccess.Client", EFOracleProviderServices.Instance);
        }
    }

    internal class OracleConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            return new OracleConnection(nameOrConnectionString);

        }
    }
}
