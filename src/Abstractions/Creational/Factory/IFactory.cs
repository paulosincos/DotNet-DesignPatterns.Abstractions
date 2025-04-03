namespace DesignPatterns.Abstractions.Creational.Factory
{
    public interface IFactory<TTarget>
    {
        TTarget Create();
    }
}
