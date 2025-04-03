namespace DesignPatterns.Abstractions.Behavioral.ChainOfResponsability
{
    public interface IResponsabilityHandler<TRequest>
    {
        public Task HandleAsync(TRequest request, Func<CancellationToken, Task> nextAsync, CancellationToken cancellationToken = default);
    }

    public interface IResponsabilityHandler<TRequest, TResponse>
    {
        public Task<TResponse> HandleAsync(TRequest request, Func<CancellationToken, Task<TResponse>> nextAsync, CancellationToken cancellationToken = default);
    }
}
