using Microsoft.Extensions.DependencyInjection;
using Playground.Implementations.ChainOfResponsability;
using Playground.Implementations.Decorator;
using Playground.Implementations.Factory;
using Playground.Implementations.Mediator;

namespace Playground.Implementations
{
    public static class ExternalServiceCollectionExtensions
    {

        public static IServiceCollection AddPlaygroundMediatorWithMiddlewares(this IServiceCollection services)
        {
            return services
                .AddInternalMediator()
                .AddInternalBasicChainer()
                .AddInternalMediatorWithMiddlewaresDecorator()
                .AddInternalMediatorWithMiddlewaresFactory()
            ;
        }

        public static IServiceCollection AddPlaygroundErrorLoggerMiddleware(this IServiceCollection services)
        {
            return services
                .AddInternalErrorLoggerHandler()
            ;
        }
    }
}
