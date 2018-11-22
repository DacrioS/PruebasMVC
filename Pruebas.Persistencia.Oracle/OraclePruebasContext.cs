using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pruebas.Entidades.OracleDF;

namespace Pruebas.Persistencia
{
    [DbConfigurationType(typeof(OracleEF6CodeConfig))]
    public class OraclePruebasContext : DbContext, IDbContext, IPruebasContext
    {
        public IDbSet<CONFIGURACIONES> Configuraciones { get; set; }
        public IDbSet<USUARIOS> Usuarios { get; set; }

        static OraclePruebasContext()
        {
            Database.SetInitializer<OraclePruebasContext>(null);
            //Database.SetInitializer(new OraclePruebasInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<OraclePruebasContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("XEPYRADMDES");
            //modelBuilder.Entity<CONFIGURACIONES>().ToTable("CONFIGURACIONES");
            //modelBuilder.Entity<USUARIOS>().ToTable("USUARIOS");
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public OraclePruebasContext(string nombreCadenaConexion) : base(nombreCadenaConexion)
        {
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
            this.Database.CommandTimeout = 90; //segundos
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        //public override int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}
    }
}
