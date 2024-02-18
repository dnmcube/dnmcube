using System.Reflection;
using Autofac;
using Autofac.Core;
using Module = Autofac.Module;

namespace Start;

public class AutofacModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Формируем путь к сборке в этой папке
        string assemblyPath = Path.Combine(appDirectory, "DataBase.dll");
        Assembly assembly = Assembly.LoadFrom(assemblyPath);
        
        string moduleName = "DataBase.AutofacModule";
        var moduleType = assembly.GetType(moduleName);
  
            // Проверяем, является ли тип Autofac модулем
            if (typeof(IModule).IsAssignableFrom(moduleType))
            {
                // Создаем экземпляр модуля
                var module = (IModule)Activator.CreateInstance(moduleType)!;

                // Регистрируем модуль в контейнере
                builder.RegisterModule(module);
            }

    }
}