using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pruebas.Repositorio;
using Pruebas.Entidades;
using System.Linq;
using Pruebas.Persistencia;

namespace Pruebas.Persistencia.Tests
{
    [TestClass]
    public class LocalDBUnitOfWorkTest
    {
        private IUnitOfWork UoW = null;

        [TestMethod]
        public void GetLocalDBConfiguracionesTest()
        {
            var confRep = UoW.Repository<Configuracion>();
            var conf = confRep.Query().Get().FirstOrDefault();
            Assert.IsNotNull(conf);
        }

        #region Inicializadores, finalizadores y constantes
        const string connStr = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=D:\LocalDB\aspnet-Pruebas.Web-20170207.mdf;Initial Catalog=aspnet-Pruebas.Web-20170207;Integrated Security=True";
        private IDbContext ctx = null;

        [TestInitialize]
        public void LocalDBUnitOfWorkTestInitialize()
        {
            IDbContext ctx = null;
            try
            {
                ctx = new LocalDBPruebasContext(connStr);
                UoW = new UnitOfWork(ctx);
            }
            catch (Exception ex) when (!System.Diagnostics.Debugger.IsAttached)
            {
                throw ex;//ToDo: Log?
            }
        }

        [TestCleanup]
        public void LocalDBUnitOfWorkTestCleanup()
        {
            if (UoW != null) UoW.Dispose();
            if (ctx != null) ctx.Dispose();
        }
        #endregion
    }
}
