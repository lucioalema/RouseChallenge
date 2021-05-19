using MarketAuction.Api.DataAccess;
using MarketAuction.Api.DataAccess.Repositories;
using MarketAuction.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketAuction.Api.Bootstrap.ServiceCollection
{
    public static class EFServiceCollectionExtensions
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var useInMemoryDatabase = bool.Parse(configuration["AppSettings:UseInMemoryDatabase"]);

            services.AddDbContext<MarketAuctionDbContext>(options =>
            {
                if (useInMemoryDatabase)
                {
                    options.UseInMemoryDatabase("MarketAuction");
                }
                else
                {
                    options.UseSqlServer(configuration.GetConnectionString("MarketAuction"));
                }
            });

            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            return services;
        }
    }
}
