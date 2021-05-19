using Autofac;
using MarketAuction.Api.Bootstrap.AutofacModules;
using Microsoft.Extensions.Configuration;

namespace MarketAuction.Api.Bootstrap.ServiceCollection
{
    public static class AutofacConfigurationServiceCollectionExtensions
    {
        public static void AddConfigurationAutofac(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterModule(new MediatorModule(bool.Parse(configuration["CommandLoggingEnabled"])));
        }
    }
}
