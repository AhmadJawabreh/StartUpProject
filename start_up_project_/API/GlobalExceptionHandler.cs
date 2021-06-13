using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace API
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                 await _next(httpContext);
            }
            catch (Exception Error) 
            {
                await HandleError(httpContext,Error);
            }
        }


        private async Task HandleError(HttpContext httpContext,Exception Error)
        {
            ProblemDetails problemDetails = new ProblemDetails();
            problemDetails.Title = Error.Message;
            problemDetails.Detail = Error.ToString();
            problemDetails.Status = (int)HttpStatusCode.BadRequest;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
