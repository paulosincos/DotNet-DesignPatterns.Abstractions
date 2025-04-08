using DesignPatterns.Abstractions.Behavioral.Mediator;
using Playground.Worker.Mediator;

namespace Playground.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider, IMediator mediator)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _mediator = mediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000);
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            var response = await _mediator.MediateAsync<TestEventRequest, TestEventResponse>(new TestEventRequest { BaseValue = 1 }, stoppingToken);
            _logger.LogInformation("Handler flow executed and returned {response}", response.Value);
        }
    }
}
