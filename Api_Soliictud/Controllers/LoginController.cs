using System;
using System.Data;
using Api_Soliictud.Models;
using Api_Soliictud.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Soliictud.Controllers
{

    public class LoginController : Controller
    {
        private readonly IServicio_Api _servicio_api;
        public LoginController(IServicio_Api servicioApi)
        {
            _servicio_api = servicioApi;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> LoginIngresar(Usuarios Ob_Solicitudes)
        {
            if (string.IsNullOrWhiteSpace(Ob_Solicitudes.UsuarioNombre) || string.IsNullOrWhiteSpace(Ob_Solicitudes.Contrasenia))
            {
                ModelState.AddModelError("", "Usuario y contraseña son obligatorios.");
                return View("Login",Ob_Solicitudes); // O la vista de login con el modelo
            }

            // Llamas al API para validar usuario y contraseña
            Usuarios obj = await _servicio_api.ObtenerDatosLogin(Ob_Solicitudes.UsuarioNombre.Trim(), Ob_Solicitudes.Contrasenia.Trim());

            if (obj == null)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
                return View("Login", Ob_Solicitudes);
            }

            // Guardar datos en sesión
            HttpContext.Session.SetString("Username", obj.NombreUusario);
            HttpContext.Session.SetString("AccountRole", obj.Rol);

            // Obtener el token JWT
            Usuarios Tokens = await _servicio_api.AutenticateUserJWT(Ob_Solicitudes.UsuarioNombre.Trim(),
                Ob_Solicitudes.Contrasenia.Trim());

            if (Tokens != null && !string.IsNullOrEmpty(Tokens.Token))
            {
                HttpContext.Session.SetString("TokenJWT", Tokens.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Error al obtener el token de autenticación.");
                return View("Login", Ob_Solicitudes);
            }
        }


    }
}
