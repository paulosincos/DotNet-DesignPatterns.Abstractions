namespace DesignPatterns.Abstractions.Behavioral.Mediator
{
    public interface IMediator
    {
        public void RegisterHandler<TRequest>(Func<IMediateHandler<TRequest>> handlerFactory);

        public void RegisterHandler<TRequest, TResponse>(Func<IMediateHandler<TRequest, TResponse>> handlerFactory);

        public Task MediateAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default);

        public Task<TResponse> MediateAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default);
    }
}
