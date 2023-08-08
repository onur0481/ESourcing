using Consul;
using SourcingService.Domain.Configurations;

namespace SourcingService.API.Extensions.Registrations
{
    public static class ConsulRegistration
    {
        public static IServiceCollection ConfigureConsul(this IServiceCollection services, IConfiguration configuration)
        {
            ConsulConfiguration? consulConfiguration = GetConsulConfiguration(configuration);
            if (consulConfiguration != null)
            {
                services.AddSingleton<IConsulClient, ConsulClient>(p =>
                    new ConsulClient(consulConfig =>
                    {
                        string? address = consulConfiguration.ConsulAddress;
                        if (address == null) return;

                        consulConfig.Address = new Uri(address);
                    }
                ));
            }

            return services;
        }

        public static IApplicationBuilder? RegisterWithConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime, IConfiguration configuration)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();

            var loggingFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();

            var logger = loggingFactory.CreateLogger<IApplicationBuilder>();

            ConsulConfiguration? consulConfiguration = GetConsulConfiguration(configuration);
            if (consulConfiguration == null) return null;

            var registration = new AgentServiceRegistration()
            {
                ID = consulConfiguration.ServiceId,
                Name = consulConfiguration.ServiceName,
                Address = consulConfiguration.ServiceAddress.Host,
                Port = consulConfiguration.ServiceAddress.Port,
                Tags = new[] { consulConfiguration.ServiceName, consulConfiguration.ServiceId }
            };

            logger.LogInformation("Registering with Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            consulClient.Agent.ServiceRegister(registration).Wait();

            lifetime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Deregistering from Consul");
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

            return app;
        }

        private static ConsulConfiguration? GetConsulConfiguration(IConfiguration configuration)
        {
            return configuration.GetSection("ConsulConfig").Get<ConsulConfiguration>();
        }
    }
}
