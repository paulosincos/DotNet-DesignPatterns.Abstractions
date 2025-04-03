namespace DesignPatterns.Abstractions.Behavioral.ChainOfResponsability
{
    public interface IResponsabilityChainer<TRequest>
    {
        public void SetAction(Func<TRequest, CancellationToken, Task> actionAsync);

        public void SetChain(IEnumerable<IResponsabilityHandler<TRequest>> responsabilityHandlers);

        public Task ChainAsync(TRequest request, CancellationToken cancellationToken = default);
    }

    public interface IResponsabilityChainer<TRequest, TResponse>
    {
        public void SetAction(Func<TRequest, CancellationToken, Task<TResponse>> actionAsync);

        public void SetChain(IEnumerable<IResponsabilityHandler<TRequest, TResponse>> responsabilityHandlers);

        public Task<TResponse> SetMainAction(TRequest request, CancellationToken cancellationToken = default);
    }
}
