using IBM.Data.DB2;
using IBM.Data.DB2.EntityFramework;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Pruebas.Persistencia
{
    public class IfxEF6CodeConfig : DbConfiguration
    {
        public IfxEF6CodeConfig()
        {
            SetDefaultConnectionFactory(new IfxConnectionFactory());
            SetProviderServices("IBM.Data.DB2", DB2ProviderServices.Instance);
        }
    }

    internal class IfxConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            return new DB2Connection(nameOrConnectionString);

        }
    }
}
