using DesignPatterns.Abstractions.Behavioral.ChainOfResponsability;

namespace Playground.Worker.Mediator
{
    internal class TestEventMiddlewareB : IResponsabilityHandler<TestEventRequest, TestEventResponse>
    {
        private readonly ILogger<TestEventMiddlewareB> _logger;

        public TestEventMiddlewareB(ILogger<TestEventMiddlewareB> logger)
        {
            _logger = logger;
        }

        public Task<TestEventResponse> HandleAsync(TestEventRequest request, Func<TestEventRequest, CancellationToken, Task<TestEventResponse>> nextAsync, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Entering middleware B");
            try
            {
                return nextAsync(request, cancellationToken);
            }
            finally
            {
                _logger.LogInformation("Exiting middleware B");
            }
        }
    }
}
