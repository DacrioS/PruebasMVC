using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pruebas.Entidades
{
    [Table("Usuarios")]
    public class Usuario
    {
        //Para asegurar el DefaultValue
        public Usuario() { Activo = true; }

        [Key]
        public int UsuarioId { get; set; }
        [MaxLength(10)][Required]
        public string Login { get; set; }
        [DefaultValue(true)]
        public bool Activo { get; set; }
        [MaxLength(1000)]
        public string NombreCompleto { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public DateTime UltimoAcceso { get; set; }
    }
}