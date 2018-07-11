using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace SakilaWeb.Middlewares {
    public class LoggerMiddleware {
        private readonly RequestDelegate next;
        private readonly LoggerMiddlewareOptions options;

        public LoggerMiddleware(RequestDelegate next, IOptions<LoggerMiddlewareOptions> options) {
            this.next = next;
            this.options = options.Value;
        }

        public async Task Invoke(HttpContext httpContext) {
            var requestPath = httpContext.Request.Path;
            string log = $"Path: {requestPath}, method: {httpContext.Request.Method}";
            File.AppendAllText(options.FileName,log);
            await next.Invoke(httpContext);
        }
    }

    public class LoggerMiddlewareOptions {
        public string FileName {get;set;}
    }

    public static class LoggerMiddlewareExtensions {
        public static IApplicationBuilder UseLoggerMiddleware(this IApplicationBuilder builder, LoggerMiddlewareOptions options) {
            return builder.UseMiddleware<LoggerMiddleware>(Options.Create(options));
        }
    }
}