﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntitiesXepyrDes : DbContext
    {
        public EntitiesXepyrDes()
            : base("name=EntitiesXepyrDes")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CONFIGURACIONES> CONFIGURACIONES { get; set; }
        public DbSet<USUARIOS> USUARIOS { get; set; }
    }
}