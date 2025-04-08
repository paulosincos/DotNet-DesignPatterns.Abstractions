using DesignPatterns.Abstractions.Behavioral.Mediator;
using DesignPatterns.Abstractions.Structural.Decorator;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Implementations.Decorator
{
    internal static class InternalServiceCollectionExtensions
    {
        public static IServiceCollection AddInternalMediatorWithMiddlewaresDecorator(this IServiceCollection services)
        {
            return services
                .AddTransient<IDecorator<IMediator>, MediatorWithMiddlewaresDecorator>()
            ;
        }
    }
}
