# 🛒 Sistema de Gestión de Solicitudes de Compra Internas

Este proyecto es una aplicación web construida con **ASP.NET Core MVC + Web API** que permite a los empleados registrar solicitudes de compra y a los supervisores aprobar o rechazar dichas solicitudes.

---

## ✅ Requisitos Técnicos

- **.NET SDK**: 6.0 o superior  
- **SQL Server**: 2019 o superior  
- **Visual Studio 2022** o Visual Studio Code  
- **Navegador**: Chrome, Edge o Firefox  
- **Puerto Web API**: `https://localhost:5001` (ajustable en `launchSettings.json`)  
- **Puerto Aplicación MVC**: `https://localhost:5002` (ajustable)

---

## 📁 Estructura del Proyecto

├── Api_Soliictud/ # Proyecto MVC
│ ├── Controllers/
│ ├── Models/
│ ├── Views/
│ ├── Middleware/
│ ├── Servicios/
│ ├── wwwroot/
│ └── Program.cs
│
├── API_CORE.WebApi/ # Proyecto Web API
│ ├── Controllers/
│ ├── Models/
│ └── Program.cs
│
├── README.md
├── .gitignore
├── SolicitudDB.sql # Script de base de datos

## 🚀 ¿Cómo iniciar el entorno?

1. **Clona el repositorio:**

```bash
git clone https://github.com/DiegoTierra27/API_CORE.git

git clone https://github.com/DiegoTierra27/Api_Soliictud.git

2. **Configura la cadena de conexión en ambos appsettings.json:

   "ConnectionStrings": {
        "DefaultConnection": "Server=LAPTOP-DTIERRA;Database=Prueba_Tecnica;User Id=sa;Password=Pa$$w0rd;TrustServerCertificate=True;"
    }


3. **Ejecuta el script SQL (SolicitudDB.sql) en SQL Server para crear la base de datos.

4. **Abre la solución en Visual Studio y establece ambos proyectos como proyectos de inicio.

5. **Presiona F5 o ejecuta

👥 Usuarios de Prueba
Rol	Usuario	Contraseña
Usuario: 	DTIERRA	1234
Supervisor:	ELLAMUCA	12345

🔐 Roles
USUARIO: Puede crear, ver y filtrar sus solicitudes.

SUPERVISOR: Puede ver solicitudes pendientes y aprobar o rechazar.

🛡 Seguridad
Login mediante JWT (token guardado en sesión).

Middleware personalizado para proteger rutas por rol.

Validación de campos obligatorios en login y formularios.

