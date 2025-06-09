using Api_Soliictud.Middleware;
using Api_Soliictud.Servicios;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios de autorizaci�n
builder.Services.AddAuthorization();
// (Opcional: si usas autenticaci�n tambi�n)
builder.Services.AddAuthentication();

// Add services to the container.


builder.Services.AddScoped<IServicio_Api, Servicio_Api>();

// Agregar servicios para controladores (MVC o API)
//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); // Almacenamiento en memoria (puede ser Redis, etc.)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiraci�n
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
// <--- A�ADE ESTA L�NEA AQU�
//app.UseMiddleware<MiddlewareApp>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
     //pattern: "{controller=Home}/{action=Index}/{id?}");
   pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
