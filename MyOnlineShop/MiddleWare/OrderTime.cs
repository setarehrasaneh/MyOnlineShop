using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOnlineShop.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class OrderTime
    {
        private readonly RequestDelegate _next;

        public OrderTime(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            if (httpContext.Request.Path.ToString().ToLower().Contains("/submitorder"))
            {
                var currentHour = DateTime.Now.Hour;

                if (! (currentHour > 8 && currentHour <= 19))
                {
                    await httpContext.Response.WriteAsync("You Cant Submit Order Before 8:00 And After 19:00");
                }
                else
                {
                    await _next.Invoke(httpContext);

                }

            }
            else
            {
                await _next.Invoke(httpContext);

            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class OrderTimeExtensions
    {
        public static IApplicationBuilder UseOrderTime(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OrderTime>();
        }
    }
}
