using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pruebas.Repositorio;
using Pruebas.Entidades.OracleDF;
using System.Linq;

namespace Pruebas.Persistencia.Tests
{
    [TestClass]
    public class OracleUnitOfWorkTest
    {
        private IUnitOfWork UoW = null;

        [TestMethod]
        public void GetOracleConfiguracionesTest()
        {
            var confRep = UoW.Repository<CONFIGURACIONES>();
            var conf = confRep.Query().Get().FirstOrDefault();
            Assert.IsNotNull(conf);
        }

        #region Inicializadores, finalizadores y constantes
        const string connStr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)"
            + "(HOST=10.8.7.10)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xepyrdes)));"
            + "User Id=xepyradmdes;Password=xepyr;";

        private IDbContext ctx = null;

        [TestInitialize]
        public void OracleUnitOfWorkTestInitialize()
        {
            IDbContext ctx = null;
            try
            {
                ctx = new OraclePruebasContext(connStr);
                UoW = new UnitOfWork(ctx);
            }
            catch (Exception ex) when (!System.Diagnostics.Debugger.IsAttached)
            {
                throw ex;//ToDo: Log?
            }
        }

        [TestCleanup]
        public void OracleUnitOfWorkTestCleanup()
        {
            if (UoW != null) UoW.Dispose();
            if (ctx != null) ctx.Dispose();
        }
        #endregion
    }
}
