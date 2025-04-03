namespace DesignPatterns.Abstractions.Structural.Decorator
{
    public interface IDecorator<TTarget>
    {
        public TTarget Decorate(TTarget target);
    }
}
