using Autofac;
using AutoMapper.QueryableExtensions;
using DBAccessor;
using DtoObjects;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using  Accessors.mechanizm;

namespace Accessors;

internal class UserAccessor<T> : AccessorAbstarct<T>, IAccessor where T : User
{
    private CRUD<T> _crud;

    public UserAccessor(ILifetimeScope lifetimeScope) : base(lifetimeScope)
    {
        _crud = lifetimeScope.Resolve<CRUD<T>>();
    }
    
    private IQueryable<T> Querys { get; set; }

    private void Query(UserFilter filter)
    {
        if (filter.Id != null)
        {
            Querys = _userRepo.GetQueryable(x => x.Id == filter.Id);
            return;
        }
        if (!string.IsNullOrEmpty(filter.Login))
        {
            Querys = _userRepo.GetQueryable(x => x.Login == filter.Login);
            return;
        }
        
        Querys = _userRepo.GetQueryable();
    }
    
    public async Task<TDto?> GiveMeDtoFirstOrDefault<TDto>(IFilter filter) where TDto : DtoObjectsAbstract, new()
    {
          Query(filter as UserFilter ?? throw new AggregateException("error UserFilter"));
          var res =  await Querys.ProjectTo<TDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
          return res;
    }
    
    
    public async Task<List<TDto>> GiveMeDtoToList<TDto>(IFilter filter) where TDto : DtoObjectsAbstract, new()
    {
        Query(filter as UserFilter ?? throw new AggregateException("error UserFilter"));
        var res =  await Querys.ProjectTo<TDto>(_mapper.ConfigurationProvider).ToListAsync();
        return res;
    }
     
    
    public async Task Add(DtoObjectsAbstract user)
    {
        await _crud.Add(user);
    }

   
}