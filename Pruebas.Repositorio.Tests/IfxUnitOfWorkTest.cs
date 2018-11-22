using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pruebas.Repositorio;
using Pruebas.Entidades;
using System.Linq;

namespace Pruebas.Persistencia.Tests
{
    [TestClass]
    public class IfxUnitOfWorkTest
    {
        private IUnitOfWork UoW = null;

        [TestMethod]
        public void GetIfxConfiguracionesTest()
        {
            var confRep = UoW.Repository<Configuracion>();
            var conf = confRep.Query().Get().FirstOrDefault();
            Assert.IsNotNull(conf);
        }

        #region Inicializadores, finalizadores y constantes
        //const string connStr = "Database=pruebasMVC; Host=172.22.213.240; Server=olsergasdes; "
        //    + "Service=1526; Protocol=onsoctcp; UserId=teresadm; Password=teresadm15";
        const string connStr = "Database=pruebasMVC;User ID=teresadm;Password=teresadm15;"
            + "Server=172.22.213.240:1526";
        private IDbContext ctx = null;

        [TestInitialize]
        public void IfxUnitOfWorkTestInitialize()
        {
            IDbContext ctx = null;
            try
            {
                ctx = new IfxPruebasContext(connStr);
                UoW = new UnitOfWork(ctx);
            }
            catch (Exception ex) when (!System.Diagnostics.Debugger.IsAttached)
            {
                throw ex;//ToDo: Log?
            }
        }

        [TestCleanup]
        public void IfxUnitOfWorkTestCleanup()
        {
            if (UoW != null) UoW.Dispose();
            if (ctx != null) ctx.Dispose();
        }
        #endregion
    }
}
