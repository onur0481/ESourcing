using EventBus.Common;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using OrderService.API.EventBusConsumers;
using OrderService.API.Extensions.Attributes;
using Serilog;

namespace OrderService.API.Extensions.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Register fluent validation
            services.AddControllers(options =>
            {
                options.Filters.Add(new ValidateFilterAttribute());
            });

            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            #endregion

            // Sets up the authentication token configurations

            // Sets up the swagger for authentication
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Rest GPT Reader"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Id="Bearer",
                                Type=ReferenceType.SecurityScheme
                            },
                            In=ParameterLocation.Header,
                            Name="Bearer"
                        },
                        new List<string>()
                    }
                });
            });

            services.AddMassTransit(config =>
            {
                config.AddConsumer<SourcingConsumer>();

                config.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);

                    cfg.ReceiveEndpoint(EventBusQueueConstants.OrderCreateQueue, x =>
                    {
                        x.ConfigureConsumer<SourcingConsumer>(context);
                    });
                });
            });

            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();

            return services;
        }
    }
}
