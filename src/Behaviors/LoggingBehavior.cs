using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace WebApiWithCqrsMediatRExample.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var reqJson = JsonSerializer.Serialize(request);
            _logger.LogInformation($"Handling {typeof(TRequest).FullName}: {reqJson ?? "null"}");
            var response = await next();
            var respJson = JsonSerializer.Serialize(response);
            _logger.LogInformation($"Handled {typeof(TResponse).FullName}: {respJson ?? "null"}");

            return response;
        }
    }
}