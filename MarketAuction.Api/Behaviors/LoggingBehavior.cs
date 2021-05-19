using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MarketAuction.Api.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            this.logger.LogInformation("Executing command {CommandName} with request {@Command}", request.GetType().FullName, request);

            TResponse response = await next();

            this.logger.LogInformation("Executed command {CommandName} with response {@Response}", request.GetType().FullName, response);

            return response;
        }
    }
}
