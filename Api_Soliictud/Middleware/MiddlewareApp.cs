namespace Api_Soliictud.Middleware
{
    public class MiddlewareApp
    {
        private readonly RequestDelegate _next;

        public MiddlewareApp(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString().ToLower();

            if (path.StartsWith("/creacionsolicitud/index"))
            {
                var rol = context.Session.GetString("AccountRole");

                if (rol != "USUARIO")
                {
                    context.Response.Redirect("/Home/SinPermisos"); // O página de acceso denegado
                    return;
                }
            }

            else if (path.StartsWith("/creacionsolicitud/filtrarporestado"))
            {
                var rol = context.Session.GetString("AccountRole");

                if (rol != "USUARIO")
                {
                    context.Response.Redirect("/Home/SinPermisos"); // O página de acceso denegado
                    return;
                }
            }

            else if (path.StartsWith("/creacionsolicitud/crearsolicitudes/0"))
            {
                var rol = context.Session.GetString("AccountRole");

                if (rol != "USUARIO")
                {
                    context.Response.Redirect("/Home/SinPermisos"); // O página de acceso denegado
                    return;
                }
            }


            else if (path.StartsWith("/creacionsolicitud/guardarnuevassolicitudes"))
            {
                var rol = context.Session.GetString("AccountRole");

                if (rol != "USUARIO")
                {
                    context.Response.Redirect("/Home/SinPermisos"); // O página de acceso denegado
                    return;
                }
            }

            else if (path.StartsWith("/bandejaaprobador/index"))
            {
                var rol = context.Session.GetString("AccountRole");

                if (rol != "SUPERVISOR")
                {
                    context.Response.Redirect("/Home/SinPermisos"); // O página de acceso denegado
                    return;
                }
            }
            else if (path.StartsWith("/bandejaaprobador/filtrarporestado"))
            {
                var rol = context.Session.GetString("AccountRole");

                if (rol != "SUPERVISOR")
                {
                    context.Response.Redirect("/Home/SinPermisos"); // O página de acceso denegado
                    return;
                }
            }



            else if (path.StartsWith("/bandejaaprobador/editarsolicitud"))
            {
                var rol = context.Session.GetString("AccountRole");

                if (rol != "SUPERVISOR")
                {
                    context.Response.Redirect("/Home/SinPermisos"); // O página de acceso denegado
                    return;
                }
            }

            await _next(context); // Continuar el pipeline

            // Antes de pasar al siguiente middleware
            //Console.WriteLine($"[Middleware] Petición a: {context.Request.Path}");

            // Llamar al siguiente middleware
           // await _next(context);

            // Después de que el siguiente middleware haya procesado la respuesta
           // Console.WriteLine($"[Middleware] Respuesta con estado: {context.Response.StatusCode}");
        }
    }

}
