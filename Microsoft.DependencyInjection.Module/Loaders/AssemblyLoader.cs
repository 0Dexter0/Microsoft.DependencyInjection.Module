using System.Reflection;

namespace Microsoft.DependencyInjection.Module.Loaders;

public static class AssemblyLoader
{
    public static IEnumerable<Assembly> LoadAssemblies()
    {
        string[] projectOutputDirectories = Directory.GetDirectories(
            Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories);

        return projectOutputDirectories
            .SelectMany(x => Directory.GetFiles(x, "*.dll"))
            .Select(Assembly.LoadFrom);
    }
}