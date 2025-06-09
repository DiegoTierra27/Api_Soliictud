using Api_Soliictud.Middleware;
using Api_Soliictud.Servicios;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios de autorización
builder.Services.AddAuthorization();
// (Opcional: si usas autenticación también)
builder.Services.AddAuthentication();

// Add services to the container.


builder.Services.AddScoped<IServicio_Api, Servicio_Api>();

// Agregar servicios para controladores (MVC o API)
//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); // Almacenamiento en memoria (puede ser Redis, etc.)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiración
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseMiMiddleware();
// <--- AÑADE ESTA LÍNEA AQUÍ
//app.UseMiddleware<MiddlewareApp>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
     //pattern: "{controller=Home}/{action=Index}/{id?}");
   pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
