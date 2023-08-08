using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SourcingService.Domain.Configurations;
using SourcingService.Domain.Repositories;
using SourcingService.Domain.Repositories.AuctionContextRepositories;
using SourcingService.Domain.Repositories.BidContextRepositories;
using SourcingService.Infrastructure.Repositories;
using SourcingService.Infrastructure.Repositories.AuctionContextRepositories;
using SourcingService.Infrastructure.Repositories.BidContextRepositories;

namespace SourcingService.Infrastructure.Extensions.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfratructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DataBaseConfiguration>(configuration.GetSection("DatabaseSettings"));
            services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IOptions<DataBaseConfiguration>>().Value);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAuctionRepository,AuctionRepository>();
            services.AddScoped<IBidRepository,BidRepository>();

            return services;
        }
    }
}
