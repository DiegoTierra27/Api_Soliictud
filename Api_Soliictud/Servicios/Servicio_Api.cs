using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using Api_Soliictud.Models;
using Newtonsoft.Json;

namespace Api_Soliictud.Servicios
{
    public class Servicio_Api : IServicio_Api
    {
        private static string _BaseUrl;

        public Servicio_Api()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _BaseUrl = builder.GetSection("ApiSettings:base_url").Value;

        }

        public async Task<List<Solicitudes>> ListaSolicitudes()
        {
            List<Solicitudes> ListaSolicitud = new List<Solicitudes>();

            var Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri(_BaseUrl);
            //Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token)
            var response = await Cliente.GetAsync("api/Solicitud/ListaSolicitud");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var Resultado = JsonConvert.DeserializeObject<Resultado_Api>(json_respuesta);
                ListaSolicitud = Resultado.Response;
            }

            return ListaSolicitud;
        }

        public async Task<Solicitudes> ListaSolicitudesxId(int IdProducto, string Token)
        {
            Solicitudes ObjSolicitud = new Solicitudes();

            var Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri(_BaseUrl);
            Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var response = await Cliente.GetAsync($"api/Solicitud/ObtenerListaSolicitudxId/{IdProducto}");

            if (response.IsSuccessStatusCode)
            {
                //var json_respuesta = await response.Content.ReadAsStringAsync();
                //var Resultado = JsonConvert.DeserializeObject<Resultado_Api2>(json_respuesta);
                //ObjSolicitud = Resultado.Objetos;

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var Resultado = JsonConvert.DeserializeObject<Resultado_Api2>(json_respuesta);
                ObjSolicitud = Resultado.Response; // <-- usa "Response" aquí

            }
            return ObjSolicitud;
        }


        public async Task<bool> GuardarSolicitudes(Solicitudes Objetos, string Token)
        {
            bool Respuesta = false;

            var Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri(_BaseUrl);
            Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var content = new StringContent(JsonConvert.SerializeObject(Objetos),Encoding.UTF8, "application/json");
            
            var response = await Cliente.PostAsync("api/Solicitud/GuardarSolicitudSolicitante/", content);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<bool> EditarSolicitudes(Solicitudes Objetos, string Token)
        {
            bool Respuesta = false;

            var Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri(_BaseUrl);
            Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var content = new StringContent(JsonConvert.SerializeObject(Objetos), Encoding.UTF8, "application/json");

            var response = await Cliente.PutAsync("api/Solicitud/EditarSolicitudSupervisor/", content);

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<bool> EliminarSolicitudes(int IdProducto)
        {
            bool Respuesta = false;

            var Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri(_BaseUrl);
            //Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token)

           /// var content = new StringContent(JsonConvert.SerializeObject(Objetos), Encoding.UTF8, "application/json");

            var response = await Cliente.DeleteAsync("/api/Solicitud/EliminarSolicitud/{IdProducto}");

            if (response.IsSuccessStatusCode)
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        public async Task<List<Solicitudes>> ObtenerListaEstadoUsuario(string Estado, string UsuarioCreacion, string Token, string Roles)
        {
            //Solicitudes ObjSolicitud = new Solicitudes();
            List<Solicitudes> ListaSolicitud = new List<Solicitudes>();

            var Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri(_BaseUrl);
            Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            ///api/Solicitud/ObtenerListaEstadoUsuario/{Estado}/{Usuario}
            var response = await Cliente.GetAsync($"api/Solicitud/ObtenerListaEstadoUsuario/{Estado}/{UsuarioCreacion}/{Roles}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var Resultado = JsonConvert.DeserializeObject<Resultado_Api>(json_respuesta);
                ListaSolicitud = Resultado.Response;
            }
            return ListaSolicitud;
        }

        
        public async Task<Usuarios> AutenticateUserJWT(string User, string Password)
        {
            Usuarios ObjSolicitud = new Usuarios();

            var Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri(_BaseUrl);
            //Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token)
            //var response = await Cliente.GetAsync($"api/Solicitud/ObtenerDatosLogin/{IdProducto}");
            var response = await Cliente.GetAsync($"api/Autenticacion/Validar/{User}/{Password}");

            if (response.IsSuccessStatusCode)
            {
                //var json_respuesta = await response.Content.ReadAsStringAsync();
                //var Resultado = JsonConvert.DeserializeObject<Resultado_Api2>(json_respuesta);
                //ObjSolicitud = Resultado.Objetos;

                var json_respuesta = await response.Content.ReadAsStringAsync();
                var Resultado = JsonConvert.DeserializeObject<Resultado_Api3>(json_respuesta);
                ObjSolicitud = Resultado.Response; // <-- usa "Response" aquí

            }
            return ObjSolicitud;
        }

        public async Task<Usuarios> ObtenerDatosLogin(string User, string Password)
        {
            Usuarios ObjSolicitud = new Usuarios();

            var Cliente = new HttpClient();
            Cliente.BaseAddress = new Uri(_BaseUrl);
            var response = await Cliente.GetAsync($"api/Autenticacion/ObtenerDatosLogin/{User}/{Password}");

            if (response.IsSuccessStatusCode)
            {
                
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var Resultado = JsonConvert.DeserializeObject<Resultado_Api3>(json_respuesta);
                ObjSolicitud = Resultado.Response; // <-- usa "Response" aquí

            }
            return ObjSolicitud;
        }
    }
}
