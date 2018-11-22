namespace Pruebas.Web.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }

        public string Login { get; set; }

        public string NombreCompleto { get; set; }

        public bool Activo { get; set; }
        
        public string Email { get; set; }

        public string UltimoAcceso { get; set; }
    }
}