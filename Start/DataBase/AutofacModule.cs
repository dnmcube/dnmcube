using Autofac;
using AutoMapper;
using mapper;
using DBAccessor;
using Data;
using  Accessors.mechanizm;

namespace DataBase;

public class AutofacModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DbDataBase>().AsSelf();
        builder.RegisterGeneric(typeof(Repo<>));
        builder.RegisterType<BaseAccessor>().As<IBaseAccessor>();
        builder.RegisterGeneric(typeof(CRUD<>));
        builder.Register(cfg => new Mapping().Configurate).As<IMapper>().InstancePerLifetimeScope();

    }
}