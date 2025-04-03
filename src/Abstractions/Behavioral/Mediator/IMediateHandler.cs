using DesignPatterns.Abstractions.Behavioral.Common;

namespace DesignPatterns.Abstractions.Behavioral.Mediator
{
    public interface IMediateHandler<TRequest>
    {
        public Task HandleAsync(TRequest request, CancellationToken cancellationToken = default);
    }

    public interface IMediateHandler<TRequest, TResponse>
        where TRequest : IResponsibleRequest<TResponse>
    {
        public Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}
