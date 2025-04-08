using DesignPatterns.Abstractions.Behavioral.Mediator;
using DesignPatterns.Abstractions.Creational.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Implementations.Factory
{
    internal static class InternalServiceCollectionExtensions
    {
        public static IServiceCollection AddInternalMediatorWithMiddlewaresFactory(this IServiceCollection services)
        {
            return services
                .AddTransient<IFactory<IMediator>, MediatorWithMiddlewaresFactory>()
                .AddTransient(sp =>
                {
                    var factory = sp.GetRequiredService<IFactory<IMediator>>();

                    return factory.Create();
                });
        }
    }
}
