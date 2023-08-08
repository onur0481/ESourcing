﻿using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Text.Json;
using Web.APIGateway.Constants;
using Web.APIGateway.DTOs.ResponseDTOs;
using Web.APIGateway.Exceptions;
using Web.APIGateway.Helpers;
using Web.APIGateway.Models;
using Web.APIGateway.Models.ConstantModels;

namespace Web.APIGateway.Extensions.Middlewares
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
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                }
            }
        }
    }
}
