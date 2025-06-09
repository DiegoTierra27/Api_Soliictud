using System.Diagnostics;
using System.Threading.Tasks;
using Api_Soliictud.Models;
using Api_Soliictud.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Api_Soliictud.Controllers
{
    public class BandejaAprobador : Controller
    {
        private readonly IServicio_Api _servicio_api;

        public BandejaAprobador(IServicio_Api servicioApi)
        {
            _servicio_api = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        public async Task<IActionResult> EditarSolicitud(int Id)
        {

            var Token = HttpContext.Session.GetString("TokenJWT");
            var Usuarip = HttpContext.Session.GetString("Username");
            var Roles = HttpContext.Session.GetString("AccountRole");

            Solicitudes Modelo_Solicitudes = new Solicitudes();

            ViewBag.Accion = "Nuevo Solicitud";

            if (Id != 0)
            {
                Modelo_Solicitudes = await _servicio_api.ListaSolicitudesxId(Id, Token);
                ViewBag.Accion = "Editar Solicitud";
            }

            return View(Modelo_Solicitudes);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarNuevasSolicitudes(Solicitudes Ob_Solicitudes)
        {
            var Token = HttpContext.Session.GetString("TokenJWT");
            var Usuarip = HttpContext.Session.GetString("Username");
            var Roles = HttpContext.Session.GetString("AccountRole");
            bool Respuesta;

            if (Ob_Solicitudes.Id == 0)
            {
                Respuesta = await _servicio_api.GuardarSolicitudes(Ob_Solicitudes, Token);
            }
            else
            {
                Respuesta = await _servicio_api.EditarSolicitudes(Ob_Solicitudes, Token);
            }

            if (Respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NoContent();
            }

        }


        
        [HttpPost]
        public async Task<IActionResult> FiltrarPorEstado(string estado)
        {
            var Token = HttpContext.Session.GetString("TokenJWT");
            var Usuarip = HttpContext.Session.GetString("Username");
            var Roles = HttpContext.Session.GetString("AccountRole");

            List<Solicitudes> ListaNew = await _servicio_api.ObtenerListaEstadoUsuario(estado, Usuarip, Token, Roles);
            return View("Index", ListaNew); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public class SolicitudController : Controller
        {
            private readonly IConfiguration _config;

            public SolicitudController(IConfiguration config)
            {
                _config = config;
            }
            public IActionResult Index()
            {
                return View(); // Muestra formulario con filtro
            }

        }

    }
}
