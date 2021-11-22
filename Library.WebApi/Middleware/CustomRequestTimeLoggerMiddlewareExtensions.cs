using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.Middleware
{
    public static class CustomRequestTimeLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomRequestTimeLogger(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomRequestTimeLoggerMiddleware>();
        }
    }
}
