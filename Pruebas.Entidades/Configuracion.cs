using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pruebas.Entidades
{
    [Table("Configuraciones")]
    public class Configuracion
    {
        #region Definición de configuraciones
        //Habituales
        public const string LDAPPath = "ldap_path";
        public const string LDAPUser = "ldap_user";
        public const string LDAPPwd = "ldap_pwd";
        public const string Entorno = "entorno";
        public const string Indice = "indice";
        public const string NumRegPag = "numero_registros_pagina";
        #endregion

        public Configuracion() { }

        [Key]
        public int ConfiguracionId { get; set; }
        [MaxLength(100)]
        public String Descripcion { get; set; }
        [MaxLength(1000)]
        public String Valor { get; set; }
    }
}
