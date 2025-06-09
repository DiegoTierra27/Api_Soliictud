using System.ComponentModel.DataAnnotations;

namespace Api_Soliictud.Models
{
    public class Usuarios
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string UsuarioNombre { get; set; }
        public string NombreUusario { get; set; }
        public string Rol { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Contrasenia { get; set; }
        public string Roles { get; set; }
        public string Token { get; set; }
    }
}
