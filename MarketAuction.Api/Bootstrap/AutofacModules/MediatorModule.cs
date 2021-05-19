using Autofac;
using MarketAuction.Api.Behaviors;
using MarketAuction.Api.Queries;
using MediatR;

namespace MarketAuction.Api.Bootstrap.AutofacModules
{
    internal class MediatorModule : Module
    {
        private readonly bool enableCommandLogging;

        public MediatorModule(bool enableCommandLogging)
        {
            this.enableCommandLogging = enableCommandLogging;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(GetMarketAuctionValue).Assembly)
                .AsImplementedInterfaces();

            if (this.enableCommandLogging)
            {
                builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            }
        }
    }
}
