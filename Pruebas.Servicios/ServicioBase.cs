using Pruebas.Entidades;
using Pruebas.Repositorio;

namespace Pruebas.Servicios
{
    public class ServicioBase
    {
        public IUnitOfWork UoW { get; set; }

        public ServicioBase(IUnitOfWork uow)
        {
            UoW = uow;
        }

        #region Definición de Repositorios
        public IRepository<Configuracion> ConfiguracionRepositorio
        {
            get { return UoW == null ? null : UoW.Repository<Configuracion>(); }
        }
        public IRepository<Usuario> UsuarioRepositorio
        {
            get { return UoW == null ? null : UoW.Repository<Usuario>(); }
        }
        #endregion
    }
}
