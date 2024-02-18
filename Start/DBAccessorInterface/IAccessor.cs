using DtoObjects;

namespace  DBAccessor;


public interface IAccessor: ICrud
{
    public  Task<T?> GiveMeDtoFirstOrDefault<T>(IFilter filter) where T : DtoObjectsAbstract, new();
    public  Task<List<T>> GiveMeDtoToList<T>(IFilter filter) where T : DtoObjectsAbstract, new();

}

public interface IFilter
{
    
}