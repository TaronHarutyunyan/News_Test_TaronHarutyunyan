using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace News_Test_TaronHarutyunyan
{
    public class MyExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public MyExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await httpContext.Response.WriteAsync(ex.Message);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyExceptionHandlingMiddleware>();
        }
    }
}
