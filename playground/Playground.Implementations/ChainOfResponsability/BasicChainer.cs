using DesignPatterns.Abstractions.Behavioral.ChainOfResponsability;

namespace Playground.Implementations.ChainOfResponsability
{
    internal class BasicChainer<TRequest> : IResponsabilityChainer<TRequest>
    {
        private IEnumerable<IResponsabilityHandler<TRequest>> _responsabilityHandlers;
        private Func<TRequest, CancellationToken, Task> _actionAsync;

        public async Task ChainAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            if (!_responsabilityHandlers.Any())
            {
                await _actionAsync(request, cancellationToken);
                return;
            }

            var handlersEnumerator = _responsabilityHandlers.GetEnumerator();

            async Task next(TRequest r, CancellationToken ct)
            {
                if (handlersEnumerator.MoveNext())
                {
                    await handlersEnumerator.Current.HandleAsync(r, next, ct);
                    return;
                }
                await _actionAsync(r, ct);
                return;
            }

            await handlersEnumerator.Current.HandleAsync(request, next, cancellationToken);
        }

        public void SetAction(Func<TRequest, CancellationToken, Task> actionAsync)
        {
            _actionAsync = actionAsync;
        }

        public void SetChain(IEnumerable<IResponsabilityHandler<TRequest>> responsabilityHandlers)
        {
            _responsabilityHandlers = responsabilityHandlers;
        }
    }

    internal class BasicChainer<TRequest, TResponse> : IResponsabilityChainer<TRequest, TResponse>
    {
        private IEnumerable<IResponsabilityHandler<TRequest, TResponse>> _responsabilityHandlers;
        private Func<TRequest, CancellationToken, Task<TResponse>> _actionAsync;

        public async Task<TResponse> ChainAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            var handlersEnumerator = _responsabilityHandlers.GetEnumerator();

            async Task<TResponse> next(TRequest r, CancellationToken ct)
            {
                if (handlersEnumerator.MoveNext())
                {
                    return await handlersEnumerator.Current.HandleAsync(r, next, ct);
                }
                return await _actionAsync(r, ct);
            }

            return await next(request, cancellationToken);
        }

        public void SetAction(Func<TRequest, CancellationToken, Task<TResponse>> actionAsync)
        {
            _actionAsync = actionAsync;
        }

        public void SetChain(IEnumerable<IResponsabilityHandler<TRequest, TResponse>> responsabilityHandlers)
        {
            _responsabilityHandlers = responsabilityHandlers;
        }
    }
}
