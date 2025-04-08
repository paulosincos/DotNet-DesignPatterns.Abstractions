using DesignPatterns.Abstractions.Behavioral.ChainOfResponsability;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Implementations.ChainOfResponsability
{
    internal static class InternalServiceCollectionExtensions
    {
        public static IServiceCollection AddInternalBasicChainer(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IResponsabilityChainer<>), typeof(BasicChainer<>))
                .AddTransient(typeof(IResponsabilityChainer<,>), typeof(BasicChainer<,>))
            ;
        }
        public static IServiceCollection AddInternalErrorLoggerHandler(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IResponsabilityHandler<>), typeof(ErrorLoggerHandler<>))
                .AddTransient(typeof(IResponsabilityHandler<,>), typeof(ErrorLoggerHandler<,>))
            ;
        }
    }
}
