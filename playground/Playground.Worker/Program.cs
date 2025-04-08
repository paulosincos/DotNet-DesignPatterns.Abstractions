using DesignPatterns.Abstractions.Behavioral.ChainOfResponsability;
using DesignPatterns.Abstractions.Behavioral.Mediator;
using Playground.Implementations;
using Playground.Worker;
using Playground.Worker.Mediator;

var builder = Host.CreateApplicationBuilder(args);
builder.Services
    .AddHostedService<Worker>()

    // engine (third party implementation)
    .AddPlaygroundMediatorWithMiddlewares()

    // middlewares (own or third party implementation)
    .AddPlaygroundErrorLoggerMiddleware()
    .AddTransient<IResponsabilityHandler<TestEventRequest, TestEventResponse>, TestEventMiddlewareA>()
    .AddTransient<IResponsabilityHandler<TestEventRequest, TestEventResponse>, TestEventMiddlewareB>()

    // handlers (own solution/domain implementation)
    .AddTransient<IMediateHandler<TestEventRequest, TestEventResponse>, TestEventHandler>()
;

var host = builder.Build();
host.Run();
