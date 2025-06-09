using Microsoft.AspNetCore.Builder;


namespace Api_Soliictud.Middleware

{
 

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareApp>();
        }
    }
}
