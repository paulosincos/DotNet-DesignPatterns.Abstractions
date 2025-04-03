namespace DesignPatterns.Abstractions.Behavioral.Strategy
{
    public interface IStrategyBase
    {
    }

    public interface IStrategy : IStrategyBase
    {
        public Task ExecuteAsync(CancellationToken cancellationToken = default);
    }

    public interface IStrategy<TRequest> : IStrategyBase
    {
        public Task ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
    }

    public interface IStrategy<TRequest, TResponse> : IStrategyBase
    {
        public Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}
