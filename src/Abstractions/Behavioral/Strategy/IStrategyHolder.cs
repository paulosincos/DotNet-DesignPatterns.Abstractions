using DesignPatterns.Abstractions.Behavioral.Common;

namespace DesignPatterns.Abstractions.Behavioral.Strategy
{
    public interface IStrategyHolder
    {
        public void SetStrategy(IStrategyBase strategy);

        public Task ExecuteAsync(CancellationToken cancellationToken = default);

        public Task ExecuteAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default);

        public Task<TResponse> ExecuteAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IResponsibleRequest<TResponse>;
    }
}
