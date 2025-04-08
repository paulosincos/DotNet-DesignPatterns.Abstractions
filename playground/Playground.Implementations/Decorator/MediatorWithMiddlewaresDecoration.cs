using DesignPatterns.Abstractions.Behavioral.ChainOfResponsability;
using DesignPatterns.Abstractions.Behavioral.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Implementations.Decorator
{
    internal class MediatorWithMiddlewaresDecoration : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public MediatorWithMiddlewaresDecoration(IMediator sourceMediator, IServiceProvider serviceProvider)
        {
            SourceMediator = sourceMediator;
            _serviceProvider = serviceProvider;
        }

        public IMediator SourceMediator { get; }

        public Task MediateAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        {
            var chainer = _serviceProvider.GetRequiredService<IResponsabilityChainer<TRequest>>();
            var chain = _serviceProvider.GetServices<IResponsabilityHandler<TRequest>>();

            chainer.SetChain(chain);
            chainer.SetAction(SourceMediator.MediateAsync);

            return chainer.ChainAsync(request, cancellationToken);
        }

        public Task<TResponse> MediateAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        {
            var chainer = _serviceProvider.GetRequiredService<IResponsabilityChainer<TRequest, TResponse>>();
            var chain = _serviceProvider.GetServices<IResponsabilityHandler<TRequest, TResponse>>();

            chainer.SetChain(chain);
            chainer.SetAction(SourceMediator.MediateAsync<TRequest, TResponse>);

            return chainer.ChainAsync(request, cancellationToken);
        }

        public void RegisterHandler<TRequest>(Func<IMediateHandler<TRequest>> handlerFactory)
        {
            SourceMediator.RegisterHandler(handlerFactory);
        }

        public void RegisterHandler<TRequest, TResponse>(Func<IMediateHandler<TRequest, TResponse>> handlerFactory)
        {
            SourceMediator.RegisterHandler(handlerFactory);
        }
    }
}
