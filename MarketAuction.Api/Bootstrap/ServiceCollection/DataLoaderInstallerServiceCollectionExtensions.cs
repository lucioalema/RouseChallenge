using MarketAuction.Api.DataAccess.Init;
using Microsoft.Extensions.DependencyInjection;

namespace MarketAuction.Api.Bootstrap.ServiceCollection
{
    public static class DataLoaderInstallerServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLoaderInitializer(this IServiceCollection services)
        {
            services.AddScoped<DataLoader>();
            return services;
        }
    }
}
