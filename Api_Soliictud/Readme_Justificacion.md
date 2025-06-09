## 🛠️ Justificación Técnica

### 🔧 Arquitectura propuesta (breve)
El sistema está desarrollado bajo una **arquitectura en dos soluciones**:

- **API REST (ASP.NET Core Web API):** expone servicios con autenticación JWT, separación de responsabilidades, y conexión a SQL Server utilizando procedimientos almacenados.
- **Cliente MVC (ASP.NET Core MVC):** consume la API mediante `HttpClient`, renderiza vistas Razor y gestiona la sesión y los roles mediante claims y middleware personalizado.

Esta separación permite una mayor escalabilidad, testeo modular y futura evolución hacia microservicios si se requiere.

---

### ✅ Validaciones clave

- **Autenticación JWT:** se valida contra las credenciales del usuario y se retorna un token firmado.
- **Roles:** se usan claims y un middleware (`MiddlewareApp`) que restringe rutas dependiendo si el usuario es `USUARIO` o `SUPERVISOR`.
- **Validaciones de negocio:**
  - Las solicitudes con monto mayor a $5000 requieren ingresar un comentario obligatorio al aprobar.
  - Solo los supervisores pueden aprobar o rechazar solicitudes.
  - Cada usuario solo puede ver y crear sus propias solicitudes.

---

### 🧠 Decisiones de diseño tomadas

- **JWT + Session híbrido:** el token JWT se almacena en `Session` para proteger rutas desde el cliente MVC sin depender completamente de cookies.
- **Middleware personalizado:** se usa un middleware para validar rutas específicas según el rol, centralizando la lógica de acceso.
- **Menú dinámico por rol:** el `Layout` de Razor muestra enlaces según el rol guardado en sesión (`USUARIO` o `SUPERVISOR`).
- **Base de datos con procedimientos almacenados:** mejora el rendimiento y permite centralizar la lógica de negocio en SQL Server.

---

### 🚀 Mejoras que aplicaría con más tiempo

- Implementar **Entity Framework Core** para mayor legibilidad y mantenibilidad del acceso a datos.
- Mejorar la **experiencia de usuario** con validaciones en el cliente usando JavaScript o Blazor Server/WebAssembly.
- Utilizar **AutoMapper** para desacoplar modelos de dominio y DTOs de respuesta.
- Agregar **logs estructurados** con `Serilog` y monitoreo con `Application Insights`.
- Desplegar en **contenedores Docker** y preparar pipelines CI/CD para despliegue automático en Azure u otro proveedor.
