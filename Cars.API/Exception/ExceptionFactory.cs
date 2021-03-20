using System.Net;
using Geekymon2.CarsApi.Cars.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Geekymon2.CarsApi.Cars.Api.Exception
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