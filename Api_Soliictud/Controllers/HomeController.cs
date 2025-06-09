using System.Diagnostics;
using System.Threading.Tasks;
using Api_Soliictud.Models;
using Api_Soliictud.Servicios;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Api_Soliictud.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_Api _servicio_api;

        public HomeController(IServicio_Api servicioApi)
        {
            _servicio_api = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
           // List<Solicitudes> ListaNew = await _servicio_api.ListaSolicitudes();

            return View();
        }

        public IActionResult SinPermisos()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            // (Opcional) si usas JWT en headers también puedes borrar la cookie/token

            // Redirige al login
            return RedirectToAction("Login", "Login");
        }
    }
}
