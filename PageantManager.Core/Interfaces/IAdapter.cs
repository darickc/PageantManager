namespace PageantManager.Core.Interfaces
{
    public interface IAdapter
    {
        TDestination Map<TDestination>(object source);
    }
}