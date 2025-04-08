using DesignPatterns.Abstractions.Behavioral.Mediator;

namespace Playground.Worker.Mediator
{
    internal class TestEventHandler(ILogger<TestEventHandler> logger) : IMediateHandler<TestEventRequest, TestEventResponse>
    {
        public Task<TestEventResponse> HandleAsync(TestEventRequest request, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Handling event");
            return Task.FromResult(new TestEventResponse { Value = request.BaseValue + 5 });
        }
    }
}
