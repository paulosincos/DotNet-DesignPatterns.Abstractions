using DesignPatterns.Abstractions.Behavioral.Mediator;
using DesignPatterns.Abstractions.Creational.Factory;
using DesignPatterns.Abstractions.Structural.Decorator;
using Microsoft.Extensions.DependencyInjection;
using Playground.Implementations.Mediator;

namespace Playground.Implementations.Factory
{
    internal class MediatorWithMiddlewaresFactory : IFactory<IMediator>
    {
        private readonly IServiceProvider _serviceProvider;

        public MediatorWithMiddlewaresFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMediator Create()
        {
            var decorators = _serviceProvider.GetServices<IDecorator<IMediator>>();
            IMediator mediator = _serviceProvider.GetRequiredService<BasicMediator>();

            foreach (var decorator in decorators)
            {
                mediator = decorator.Decorate(mediator);
            }

            return mediator;
        }
    }
}
