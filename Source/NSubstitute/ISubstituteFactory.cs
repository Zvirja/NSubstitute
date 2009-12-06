namespace NSubstitute
{
    public interface ISubstituteFactory
    {
        T Create<T>() where T : class;
    }
}