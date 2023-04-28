using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.DependencyInjection.Module.InjectionModules;

public abstract class InjectionModuleBase
{
    public abstract void Load(IServiceCollection services);
}