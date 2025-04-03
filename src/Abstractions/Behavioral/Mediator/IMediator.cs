using DesignPatterns.Abstractions.Behavioral.Common;

namespace DesignPatterns.Abstractions.Behavioral.Mediator
{
    public interface IMediator
    {
        public Task MediateAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default);

        public Task<TResponse> MediateAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IResponsibleRequest<TResponse>;
    }
}
