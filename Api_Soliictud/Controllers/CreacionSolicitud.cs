using System.Diagnostics;
using System.Threading.Tasks;
using Api_Soliictud.Models;
using Api_Soliictud.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Api_Soliictud.Controllers
{
    public class CreacionSolicitud : Controller
    {
        private readonly IServicio_Api _servicio_api;

        public CreacionSolicitud(IServicio_Api servicioApi)
        {
            _servicio_api = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> CrearSolicitudes(int Id)
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
            bool Respuesta;
            var Token = HttpContext.Session.GetString("TokenJWT");
            var Usuarip = HttpContext.Session.GetString("Username");
            var Roles = HttpContext.Session.GetString("AccountRole");

            if (Ob_Solicitudes.Id == 0)
            {
                Ob_Solicitudes.Acciones = Usuarip;
                Respuesta = await _servicio_api.GuardarSolicitudes(Ob_Solicitudes, Token);
            }
            else
            {
                Ob_Solicitudes.Acciones = Usuarip;
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
            //ViewBag["estado"] = estado;
            return View("Index", ListaNew); // 👈 Esto evita el error
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
