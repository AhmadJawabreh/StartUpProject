using Contract.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;


namespace API
{


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
            catch (NotFoundException notFoundException)
            {
                await HandleError(httpContext, notFoundException, HttpStatusCode.NotFound);
            }
            catch (InvalidArgumentException invalidArgumentExceptio)
            {
                await HandleError(httpContext, invalidArgumentExceptio, HttpStatusCode.BadRequest);
            }
            catch (DubplicateDataException dubplicateDataException)
            {
                await HandleError(httpContext, dubplicateDataException, HttpStatusCode.Conflict);
            }
            catch (Exception Error)
            {
                   await HandleError(httpContext, Error, HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleError(HttpContext httpContext, Exception Error, HttpStatusCode Status)
        {
            ProblemDetails problemDetails = new ProblemDetails();
            problemDetails.Title = Error.Message;
            problemDetails.Detail = Error.ToString();
            problemDetails.Status = (int)Status;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }

    public static class GlobalExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandler>();
        }
    }
}
