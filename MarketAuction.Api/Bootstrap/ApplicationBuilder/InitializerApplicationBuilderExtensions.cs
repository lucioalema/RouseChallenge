using System;
using MarketAuction.Api.DataAccess.Init;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MarketAuction.Api.Bootstrap.ApplicationBuilder
{
    public static class InitializerApplicationBuilderExtensions
    {
        public static void UseInitializer(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetService<DataLoader>();
                initializer.Seed();
            }
        }
    }
}
