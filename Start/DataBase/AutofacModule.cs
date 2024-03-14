using Autofac;
using AutoMapper;
using mapper;
using Data;
using  Accessors.mechanizm;


namespace DataBase;

public class AutofacModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DbDataBase>().AsSelf();
         builder.RegisterType<Repository>().As<IAccessor>();
        builder.Register(cfg => new Mapping().Configurate).As<IMapper>().InstancePerLifetimeScope();
    }
    
}