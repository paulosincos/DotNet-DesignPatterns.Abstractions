using DesignPatterns.Abstractions.Behavioral.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Implementations.Mediator
{
    internal static class InternalServiceCollectionExtensions
    {
        public static IServiceCollection AddInternalMediator(this IServiceCollection services)
        {
            return services.AddTransient<BasicMediator>()
                .AddTransient<IMediator, BasicMediator>();
        }
    }
}
