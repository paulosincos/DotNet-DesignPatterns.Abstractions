using DesignPatterns.Abstractions.Behavioral.ChainOfResponsability;

namespace Playground.Worker.Mediator
{
    internal class TestEventMiddlewareA : IResponsabilityHandler<TestEventRequest, TestEventResponse>
    {
        private readonly ILogger<TestEventMiddlewareA> _logger;

        public TestEventMiddlewareA(ILogger<TestEventMiddlewareA> logger)
        {
            _logger = logger;
        }

        public Task<TestEventResponse> HandleAsync(TestEventRequest request, Func<TestEventRequest, CancellationToken, Task<TestEventResponse>> nextAsync, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Entering middleware A");
            try
            {
                return nextAsync(request, cancellationToken);
            }
            finally
            {
                _logger.LogInformation("Exiting middleware A");
            }
        }
    }
}
