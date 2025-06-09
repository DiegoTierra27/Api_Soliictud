using Api_Soliictud.Models;

namespace Api_Soliictud.Servicios
{
    public interface IServicio_Api
    {
        Task<List<Solicitudes>> ListaSolicitudes();
        Task<Solicitudes> ListaSolicitudesxId(int IdProducto, string Token);
        Task<bool> GuardarSolicitudes(Solicitudes Objetos, string Token);
        Task<bool> EditarSolicitudes(Solicitudes Objetos, string Token);
        Task<bool> EliminarSolicitudes(int IdProducto);

        Task<List<Solicitudes>> ObtenerListaEstadoUsuario(string Estado, string UsuarioCreacion, string Token, string Roles);

        Task<Usuarios> AutenticateUserJWT(string  User, string Password);
        Task<Usuarios> ObtenerDatosLogin(string User, string Password);
    }
}
