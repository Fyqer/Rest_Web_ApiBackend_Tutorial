using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestTutorial.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public ErrorHandlingMiddleware()
        {

        }

        public async  Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);

            }
            catch (Exception e )
            {

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Wystapil wyjatek");
            }
        }
    }
}
