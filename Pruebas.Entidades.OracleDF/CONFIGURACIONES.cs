//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pruebas.Entidades.OracleDF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CONFIGURACIONES
    {
        [Key]
        public decimal CONFIGURACIONID { get; set; }
        [MaxLength(100)]
        public string DESCRIPCION { get; set; }
        [MaxLength(1000)]
        public string VALOR { get; set; }
    }
}
