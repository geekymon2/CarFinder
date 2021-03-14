using System.Net;
using GeekyMon2.CarsApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace GeelyMon2.CarsApi.Exception
{
    public static class ExceptionFactory
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError => 
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null) 
                    {
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                    }

                    await context.Response.WriteAsync(new ErrorDetails() 
                    {
                        StatusCode = context.Response.StatusCode,
                        ErrorMessage = "Internal Server Error."
                    }.ToString());                   
                });

            });
        }
        
    }
}