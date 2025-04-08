using DesignPatterns.Abstractions.Behavioral.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.Implementations.Mediator
{
    internal class BasicMediator(IServiceProvider serviceProvider) : IMediator
    {
        private readonly Dictionary<Type, Delegate> _handlers = [];

        public async Task MediateAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        {
            // TODO: Caching
            var handlerType = typeof(IMediateHandler<>).MakeGenericType(typeof(TRequest));
            var handler = GetHandler(handlerType);

            // TODO: Caching
            var methodInfo = handlerType.GetType().GetMethod(nameof(IMediateHandler<TRequest>.HandleAsync));
            Task invoker(object handler, TRequest request, CancellationToken cancellationToken) =>
                (methodInfo.Invoke(handler, [request, cancellationToken]) as Task)!;

            await invoker(handler, request, cancellationToken);
        }

        public async Task<TResponse> MediateAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        {
            // TODO: Caching
            var handlerType = typeof(IMediateHandler<,>).MakeGenericType(typeof(TRequest), typeof(TResponse));
            var handler = GetHandler(handlerType);

            // TODO: Caching
            var methodInfo = handlerType.GetMethod(nameof(IMediateHandler<TRequest>.HandleAsync));
            Task<TResponse> invoker(object handler, TRequest request, CancellationToken cancellationToken) =>
                (methodInfo.Invoke(handler, [request, cancellationToken]) as Task<TResponse>)!;

            return await invoker(handler, request, cancellationToken);
        }

        public void RegisterHandler<TRequest>(Func<IMediateHandler<TRequest>> handlerFactory)
        {
            _handlers[typeof(IMediateHandler<TRequest>)] = handlerFactory;
        }

        public void RegisterHandler<TRequest, TResponse>(Func<IMediateHandler<TRequest, TResponse>> handlerFactory)
        {
            _handlers[typeof(IMediateHandler<TRequest, TResponse>)] = handlerFactory;
        }

        private object GetHandler(Type handlerType)
        {
            var handlerFactory = GetHandlerFactory(handlerType);

            // TODO: generate/compile and cache it
            var handler = handlerFactory.DynamicInvoke();
            return handler;
        }

        private Delegate GetHandlerFactory(Type handlerType)
        {
            if (_handlers.TryGetValue(handlerType, out var handlerFactory))
            {
                return handlerFactory;
            }

            return () => serviceProvider.GetRequiredService(handlerType)
                ?? throw new InvalidOperationException("No handler for this request");
        }
    }
}
