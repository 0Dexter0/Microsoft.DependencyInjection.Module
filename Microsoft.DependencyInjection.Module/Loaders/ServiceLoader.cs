using Microsoft.DependencyInjection.Module.InjectionModules;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.DependencyInjection.Module.Loaders;

public static class ServiceLoader
{
    public static void Load(IServiceCollection services)
    {
        var injectModules = AssemblyLoader.LoadAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(InjectionModuleBase).IsAssignableFrom(x) && !x.IsAbstract).ToList();

        injectModules.ForEach(x =>
        {
            var module = Activator.CreateInstance(x);
            x.GetMethod(nameof(InjectionModuleBase.Load))?.Invoke(module, new object []{ services });
        });
    }
}