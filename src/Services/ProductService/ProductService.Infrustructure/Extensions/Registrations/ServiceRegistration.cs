using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProductService.Domain.Configurations;
using ProductService.Domain.Repositories;
using ProductService.Domain.Repositories.ProductContextRepositories;
using ProductService.Infrustructure.Repositories;
using ProductService.Infrustructure.Repositories.ProductContextRepositories;

namespace ProductService.Infrustructure.Extensions.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DataBaseConfiguration>(configuration.GetSection("DatabaseSettings"));
            services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IOptions<DataBaseConfiguration>>().Value);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
