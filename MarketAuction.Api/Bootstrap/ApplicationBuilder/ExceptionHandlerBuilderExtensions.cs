using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketAuction.Api.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MarketAuction.Api.Bootstrap.ApplicationBuilder
{
    public static class ExceptionHandlerBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder, bool includeErrorDetailInResponse = false)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>(includeErrorDetailInResponse);
        }
    }

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly bool includeErrorDetailInResponse;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger, bool includeErrorDetailInResponse)
        {
            this.next = next;
            this.logger = logger;
            this.includeErrorDetailInResponse = includeErrorDetailInResponse;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var exceptionHandlerPathFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is NotFoundDomainException notFoundDomainException)
            {
                string errorObject = JsonConvert.SerializeObject(new
                {
                    errors = new
                    {
                        message = this.CutArgumentMessage(notFoundDomainException.Message)
                    }
                });

                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(errorObject, Encoding.UTF8);
            }
            else if (exceptionHandlerPathFeature?.Error is DomainException domainException)
            {
                string errorObject = JsonConvert.SerializeObject(new
                {
                    errors = new
                    {
                        message = this.CutArgumentMessage(domainException.Message)
                    }
                });

                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(errorObject, Encoding.UTF8);
            }
            else if (exceptionHandlerPathFeature?.Error is ArgumentException argumentException)
            {
                string errorObject = JsonConvert.SerializeObject(new
                {
                    errors = new
                    {
                        property = argumentException.ParamName,
                        message = this.CutArgumentMessage(argumentException.Message)
                    }
                });

                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(errorObject, Encoding.UTF8);
            }
            else
            {
                await this.WriteGenericErrorToResponse(
                    httpContext,
                    new Exception(
                        $"Unhandled by {nameof(ExceptionHandlerMiddleware)}",
                        exceptionHandlerPathFeature.Error).ToString());
            }
        }

        private string CutArgumentMessage(string mssg)
        {
            return mssg.Split(Environment.NewLine).FirstOrDefault();
        }

        private async Task WriteGenericErrorToResponse(HttpContext httpContext, object errorDetail)
        {
            string errorObject = JsonConvert.SerializeObject(
                new
                {
                    Error = "Ocurrio un error en la Aplicacion. Por favor intentá mas tarde.",
                    Detail = this.includeErrorDetailInResponse ? errorDetail : null
                },
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Formatting = Formatting.Indented
                });

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(errorObject, Encoding.UTF8);
        }
    }
}
