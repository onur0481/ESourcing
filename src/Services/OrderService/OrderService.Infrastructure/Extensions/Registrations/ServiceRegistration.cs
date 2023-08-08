using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Domain.Configurations;
using OrderService.Domain.Repositories;
using OrderService.Domain.Repositories.OrderContextRepositories;
using OrderService.Infrastructure.Context;
using OrderService.Infrastructure.Repositories;
using OrderService.Infrastructure.Repositories.OrderRepositories;
using System.Reflection;

namespace OrderService.Infrastructure.Extensions.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            DatabaseConfiguration? databaseConfiguration = GetDatabaseConfiguration(configuration);
            if (databaseConfiguration != null)
            {
                services.AddDbContext<OrderDbContext>(opt =>
                {
                    opt.UseSqlServer(databaseConfiguration.OrderDBConnectionString, asm =>
                    {
                        asm.MigrationsAssembly(Assembly.GetAssembly(typeof(OrderDbContext))?.GetName().Name);
                    });
                });
            }

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }

        private static DatabaseConfiguration? GetDatabaseConfiguration(IConfiguration configuration)
        {
            return configuration?.GetSection("ConnectionStrings").Get<DatabaseConfiguration>();
        }
    }
}
