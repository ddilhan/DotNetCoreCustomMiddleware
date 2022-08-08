using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace CustomMidleware.Middlewares
{
    public class ReqestOriginMidleware
    {
        private readonly RequestDelegate _next;
        public ReqestOriginMidleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
        {
            context.Response.Cookies.Append("ENV", env.EnvironmentName);
            
            await _next(context);
        }
    }
}
