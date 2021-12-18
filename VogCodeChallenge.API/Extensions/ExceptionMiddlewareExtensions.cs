using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using VogCodeChallenge.BLL.Objects;

namespace VogCodeChallenge.API.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var errorDetails = new ErrorDetails();
                        if (contextFeature.Error.GetType() == typeof(VogCodeChallengeStartupException))
                        {
                            errorDetails.Message = $"VogCodeChallengeStartupException Message '{contextFeature.Error.Message}'.";
                            errorDetails.StatusCode = HttpStatusCode.NonAuthoritativeInformation;
                        }
                        else if (contextFeature.Error.GetType() == typeof(VogCodeChallengeStartupException))
                        {
                            errorDetails.Message = $"VogCodeChallengeStartupException Message '{contextFeature.Error.Message}'.";
                            errorDetails.StatusCode = HttpStatusCode.InternalServerError;
                        }
                        else
                        {
                            errorDetails.Message = $"An error occured. '{contextFeature.Error.Message}'.";
                            errorDetails.StatusCode = HttpStatusCode.InternalServerError;
                        }
                        errorDetails.InnerException = contextFeature.Error.InnerException;

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int)errorDetails.StatusCode;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDetails));
                    }
                });
            });
        }
    }
}