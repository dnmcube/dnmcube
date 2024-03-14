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

        List<string> names = new List<string>()
        {
            "DataBase.dll",
            "Rules.dll"
        };
        // Формируем путь к сборке в этой папке
       
        foreach (var item in names)
        {
            string fulladdress = Path.Combine(appDirectory, item);

            Assembly assembly = Assembly.LoadFrom(fulladdress);
        
            string moduleName = item.Split(".")[0]+".AutofacModule";
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
}