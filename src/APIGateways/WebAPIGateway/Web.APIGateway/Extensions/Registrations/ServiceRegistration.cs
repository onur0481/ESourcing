using Ocelot.DependencyInjection;
using Ocelot.Provider.Consul;
using Serilog;

namespace Web.APIGateway.Extensions.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAPIGatewayServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add Ocelot
            services.AddOcelot().AddConsul();



            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();

            return services;
        }
    }
}
