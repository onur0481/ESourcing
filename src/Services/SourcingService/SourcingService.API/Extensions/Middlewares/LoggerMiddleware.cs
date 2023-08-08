using SourcingService.Application.DTOs.ResponseDTOs;
using SourcingService.Application.Helpers;
using SourcingService.Domain.Constants;
using SourcingService.Domain.Exceptions;
using SourcingService.Domain.Models;
using SourcingService.Domain.Models.ConstantModels;
using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace SourcingService.API.Extensions.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            string? correlationId = context.Request.Headers["CorrelationId"].FirstOrDefault();
            if (correlationId == null)
            {
                correlationId = Guid.NewGuid().ToString();
                context.Request.Headers.Add("CorrelationId", correlationId);
            }

            HttpRequest request = context.Request;

            Exception? exception = null;
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            finally
            {
                HttpStatusCode statusCode = exception switch
                {
                    null => HttpStatusCode.OK,
                    ClientSideException => HttpStatusCode.BadRequest,
                    _ => HttpStatusCode.InternalServerError,
                };

                LoggerHelper.Log(new LogModel(
                    serviceName: Assembly.GetEntryAssembly()?.GetName().Name ?? "Unknown",
                    requestMethod: request.Method,
                    requestPath: request.Path,
                    requestID: correlationId,
                    ipAddress: request.Host.ToString(),
                    responseStatusCode: (int)statusCode,
                    elapsedTimeInMilliseconds: stopwatch.ElapsedMilliseconds,
                    errorMessage: exception?.Message,
                    innerExceptionMessage: exception?.InnerException?.Message
                    ));

                // sets response body
                if (exception != null)
                {
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    ExceptionConstantModel error = statusCode switch
                    {
                        HttpStatusCode.InternalServerError => ExceptionConstants.ServerSideError,
                        _ => exception is not ClientSideException clientSideException ? ExceptionConstants.ServerSideError : new ExceptionConstantModel(clientSideException.Code, clientSideException.Message)
                    };

                    context.Response.StatusCode = (int)statusCode;

                    APIResponseDTO response = new(statusCode, error);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    }));
                }
            }
        }
    }
}
