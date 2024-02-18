using Autofac;
using AutoMapper;
using Data.Context;
using DataBase;
namespace Accessors.mechanizm;

internal abstract class AccessorAbstarct<T> where T:BaseEntity
{
    protected Repo<T> _userRepo;
    protected readonly IMapper _mapper;
    protected ILifetimeScope _lifetimeScope;
    public AccessorAbstarct(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
        _userRepo = _lifetimeScope.Resolve<Repo<T>>();
        _mapper = _lifetimeScope.Resolve<IMapper>();
    }
}