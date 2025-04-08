using DesignPatterns.Abstractions.Behavioral.Mediator;
using DesignPatterns.Abstractions.Structural.Decorator;

namespace Playground.Implementations.Decorator
{
    internal class MediatorWithMiddlewaresDecorator : IDecorator<IMediator>
    {
        private readonly IServiceProvider _serviceProvider;

        public MediatorWithMiddlewaresDecorator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMediator Decorate(IMediator target)
        {
            return new MediatorWithMiddlewaresDecoration(target, _serviceProvider);
        }
    }
}
