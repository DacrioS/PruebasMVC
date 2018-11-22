using Pruebas.Entidades;
using System.Collections.Generic;
using System.Data.Entity;

namespace Pruebas.Persistencia
{
    public class IfxPruebasInitializer :
        CreateDatabaseIfNotExists<IfxPruebasContext>
        //DropCreateDatabaseIfModelChanges<IfxPruebasContext>
        //DropCreateDatabaseAlways<IfxPruebasContext>
    {
        protected override void Seed(IfxPruebasContext context)
        {
            PoblarConfiguracionDemo().ForEach(x => context.Configuraciones.Add(x));
            PoblarUsuariosDemo().ForEach(x => context.Usuarios.Add(x));
            base.Seed(context);
        }

        private static List<Configuracion> PoblarConfiguracionDemo()
        {
            return new List<Configuracion>
            {
                new Configuracion
                {
                    Descripcion = "ldap_path",
                    Valor = "rutaLDAP"
                },
                new Configuracion
                {
                    Descripcion = "ldap_user",
                    Valor = "usuarioLDAP"
                },
                new Configuracion
                {
                    Descripcion = "ldap_pwd",
                    Valor = "contraseñaLDAP"
                },
                new Configuracion
                {
                    Descripcion = "entorno",
                    Valor = "DES"
                },
                new Configuracion
                {
                    Descripcion = "indice",
                    Valor = "~/Index.aspx"
                },
                new Configuracion
                {
                    Descripcion = "numero_registros_pagina",
                    Valor = "30"
                }
            };
        }

        private static List<Usuario> PoblarUsuariosDemo()
        {
            var now = System.DateTime.Now;
            return new List<Usuario>
            {
                new Usuario
                {
                    Login = "sperez",
                    Activo = true,
                    NombreCompleto = "Pérez Santiago, Severino",
                    Email = "sperez@indra.es",
                    UltimoAcceso = now
                },
                new Usuario
                {
                    Login = "sperezCl1",
                    Activo = false,
                    NombreCompleto = "Clon Uno, Severino",
                    Email = "sperez1@indra.es",
                    UltimoAcceso = now
                },
                new Usuario
                {
                    Login = "sperezCl2",
                    Activo = false,
                    NombreCompleto = "Clon Dos, Severino",
                    Email = "sperez2@indra.es",
                    UltimoAcceso = now
                }
            };
        }
    }
}
