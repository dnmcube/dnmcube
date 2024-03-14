using System.Linq.Expressions;
using Autofac;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Context;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Accessors.mechanizm;

internal class Repository :IAccessor 
{
    private  DbDataBase _context { get; }
    protected readonly IMapper _mapper;
    protected readonly ILifetimeScope _lifetimeScope;

    
    public Repository(ILifetimeScope lifetimeScope)
    {
        _context = lifetimeScope.Resolve<DbDataBase>();
        _mapper = lifetimeScope.Resolve<IMapper>();;
        _lifetimeScope = lifetimeScope;
    }

    public DbDataBase Get()
    {
        return _context;
    }
    
    public  Task<TDto> FirstOrDefault<TDto, T>(Expression<Func<T,bool>> filter) where T : BaseDto 
    {
        var querys = _context.Set<T>().Where(filter);
        var query =  querys.ProjectTo<TDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        return query;
    }

    public  Task<List<TDto>> ToList<TDto, TEntity>(Expression<Func<TEntity,bool>> filter) where TEntity : BaseDto 
    {

        var querys = _context.Set<TEntity>().Where(filter);
        var query =  querys.ProjectTo<TDto>(_mapper.ConfigurationProvider).ToListAsync();
        return query;
    }

    public  Task<List<TEntity>> ToList<TEntity>(Expression<Func<TEntity,bool>> filter) where TEntity : BaseDto 
    {
        var querys = _context.Set<TEntity>().Where(filter);
        var query =  querys.ProjectTo<TEntity>(_mapper.ConfigurationProvider).ToListAsync();
        return query;
    }

    public async Task Add<TEntity>(TEntity user) where TEntity : BaseDto
    {
          var res = _mapper.Map<TEntity>(user);
         _context.Add(res);
         await _context.SaveChangesAsync();
    }
    
    public async Task Add<TDto,TEntity>(TDto user) where TEntity : BaseDto
    {
        var res = _mapper.Map<TEntity>(user);
        _context.Add(res);
        await _context.SaveChangesAsync();
    }
}