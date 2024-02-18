using Autofac;
using DbAccessorInterfaces;

namespace DbAccessor;

public class AutofacModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserAccess>().As<IUserAccess>();
    }
}