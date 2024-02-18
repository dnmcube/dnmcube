using Autofac;
using DBAccessor;
using Data.Context;

namespace Accessors.mechanizm;

internal class BaseAccessor:IBaseAccessor
{
    private ILifetimeScope _lifetimeScope;
    public BaseAccessor(ILifetimeScope lifetimeScope)
    {
        _lifetimeScope = lifetimeScope;
    }

    public IAccessor userAccessor => new UserAccessor<User>(_lifetimeScope);
    public IAccessor bookAccessor => new BookAccessor<Book>(_lifetimeScope);
    
}