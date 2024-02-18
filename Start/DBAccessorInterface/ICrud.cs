using DtoObjects;

namespace DBAccessor;

public interface ICrud
{
    public Task Add(DtoObjectsAbstract user);

}