using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pruebas.Entidades;

namespace Pruebas.Persistencia
{
    [DbConfigurationType(typeof(LocalDBEF6CodeConfig))]
    public class LocalDBPruebasContext : DbContext, IDbContext, IPruebasContext
    {
        public IDbSet<Configuracion> Configuraciones { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }

        static LocalDBPruebasContext()
        {
            //Database.SetInitializer<PruebasContext>(null);
            Database.SetInitializer(new PruebasInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<PruebasContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public LocalDBPruebasContext(string nombreCadenaConexion) : base(nombreCadenaConexion)
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
