using Pruebas.Entidades.OracleDF;
using System.Collections.Generic;
using System.Data.Entity;

namespace Pruebas.Persistencia
{
    public class OraclePruebasInitializer :
        CreateDatabaseIfNotExists<OraclePruebasContext>
        //DropCreateDatabaseIfModelChanges<OraclePruebasContext>
        //DropCreateDatabaseAlways<OraclePruebasContext>
    {
        protected override void Seed(OraclePruebasContext context)
        {
            PoblarConfiguracionDemo().ForEach(x => context.Configuraciones.Add(x));
            PoblarUsuariosDemo().ForEach(x => context.Usuarios.Add(x));
            base.Seed(context);
        }

        private static List<CONFIGURACIONES> PoblarConfiguracionDemo()
        {
            return new List<CONFIGURACIONES>
            {
                new CONFIGURACIONES
                {
                    DESCRIPCION = "ldap_path",
                    VALOR = "rutaLDAP"
                },
                new CONFIGURACIONES
                {
                    DESCRIPCION = "ldap_user",
                    VALOR = "usuarioLDAP"
                },
                new CONFIGURACIONES
                {
                    DESCRIPCION = "ldap_pwd",
                    VALOR = "contraseñaLDAP"
                },
                new CONFIGURACIONES
                {
                    DESCRIPCION = "entorno",
                    VALOR = "DES"
                },
                new CONFIGURACIONES
                {
                    DESCRIPCION = "indice",
                    VALOR = "~/Index.aspx"
                },
                new CONFIGURACIONES
                {
                    DESCRIPCION = "numero_registros_pagina",
                    VALOR = "30"
                }
            };
        }

        private static List<USUARIOS> PoblarUsuariosDemo()
        {
            var now = System.DateTime.Now;
            return new List<USUARIOS>
            {
                new USUARIOS
                {
                    LOGIN = "sperez",
                    ACTIVO = 1,
                    NOMBRECOMPLETO = "Pérez Santiago, Severino",
                    EMAIL = "sperez@indra.es",
                    ULTIMOACCESO = now
                },
                new USUARIOS
                {
                    LOGIN = "sperezCl1",
                    ACTIVO = 0,
                    NOMBRECOMPLETO = "Clon Uno, Severino",
                    EMAIL = "sperez1@indra.es",
                    ULTIMOACCESO = now
                },
                new USUARIOS
                {
                    LOGIN = "sperezCl2",
                    ACTIVO = 0,
                    NOMBRECOMPLETO = "Clon Dos, Severino",
                    EMAIL = "sperez2@indra.es",
                    ULTIMOACCESO = now
                }
            };
        }
    }
}
