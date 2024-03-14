using System.Linq.Expressions;
using Data.Context;

namespace  Accessors.mechanizm;


public interface IAccessor
{
    public Task<TDto> FirstOrDefault<TDto, T>(Expression<Func<T,bool>> filter) where T : BaseDto;
    public Task<List<TDto>> ToList<TDto,TEntity>(Expression<Func<TEntity ,bool>> filter)   where TEntity : BaseDto;
    public Task<List<TEntity>> ToList<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : BaseDto;

    Task Add<TEntity>(TEntity user) where TEntity : BaseDto;
    Task Add<TDto, TEntity>(TDto user) where TEntity : BaseDto;

}
