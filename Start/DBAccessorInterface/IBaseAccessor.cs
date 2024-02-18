
namespace DBAccessor;

public interface IBaseAccessor
{
    public IAccessor userAccessor { get; }
    public IAccessor bookAccessor { get; }
}