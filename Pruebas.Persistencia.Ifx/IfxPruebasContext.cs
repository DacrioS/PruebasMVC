using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pruebas.Entidades;

namespace Pruebas.Persistencia
{
    [DbConfigurationType(typeof(IfxEF6CodeConfig))]
    public class IfxPruebasContext : DbContext, IDbContext, IPruebasContext
    {
        public IDbSet<Configuracion> Configuraciones { get; set; }
        public IDbSet<Usuario> Usuarios { get; set; }

        static IfxPruebasContext()
        {
            Database.SetInitializer<IfxPruebasContext>(null);
            //Database.SetInitializer(new IfxPruebasInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<IfxPruebasContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public IfxPruebasContext(string nombreCadenaConexion) : base(nombreCadenaConexion)
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
