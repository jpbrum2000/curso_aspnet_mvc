using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SakilaWeb.Middlewares {
    public class LoggerMiddleware {
        private readonly RequestDelegate next;
        private readonly LoggerMiddlewareOptions options;

        public LoggerMiddleware(RequestDelegate next, LoggerMiddlewareOptions options) {
            this.next = next;
            this.options = options;
        }

        public async Task Invoke(HttpContext httpContext) {
            var requestPath = httpContext.Request.Path;
            Console.WriteLine("LoggerMiddleware, registrando "+ requestPath);

            await next.Invoke(httpContext);
        }
    }

    public class LoggerMiddlewareOptions {
        public string FileName {get;set;}
    }
}