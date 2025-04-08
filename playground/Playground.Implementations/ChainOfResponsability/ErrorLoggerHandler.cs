using DesignPatterns.Abstractions.Behavioral.ChainOfResponsability;
using Microsoft.Extensions.Logging;

namespace Playground.Implementations.ChainOfResponsability
{
    public class ErrorLoggerHandler<TRequest> : IResponsabilityHandler<TRequest>
    {
        private readonly ILogger<ErrorLoggerHandler<TRequest>> _logger;

        public ErrorLoggerHandler(ILogger<ErrorLoggerHandler<TRequest>> logger)
        {
            _logger = logger;
        }

        public bool SuppressErrors { get; set; }

        public async Task HandleAsync(TRequest request, Func<TRequest, CancellationToken, Task> nextAsync, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Entering error logger middleware");
            try
            {
                await nextAsync(request, cancellationToken);
                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception was thrown: {Message}", ex.Message);
                if (!SuppressErrors)
                {
                    throw;
                }
            }
            finally
            {
                _logger.LogInformation("Exiting error logger middleware");
            }
        }
    }
    public class ErrorLoggerHandler<TRequest, TResponse> : IResponsabilityHandler<TRequest, TResponse>
    {
        private readonly ILogger<ErrorLoggerHandler<TRequest, TResponse>> _logger;

        public ErrorLoggerHandler(ILogger<ErrorLoggerHandler<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public bool SuppressErrors { get; set; }

        public async Task<TResponse> HandleAsync(TRequest request, Func<TRequest, CancellationToken, Task<TResponse>> nextAsync, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Entering error logger middleware");
            try
            {
                return await nextAsync(request, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception was thrown: {Message}", ex.Message);
                if (!SuppressErrors)
                {
                    throw;
                }

                return default!;
            }
            finally
            {
                _logger.LogInformation("Exiting error logger middleware");
            }
        }
    }
}
