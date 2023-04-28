This package allows you use Microsoft DI anywhere in your project.
Please find below an example of using:

- Let's create some service for binding:

```csharp
public interface ISomeService
{
    string GetServiceName();
}

internal class SomeService : ISomeService
{
    public string GetServiceName() => nameof(SomeService);
}
```

- Next you need to create a class which must be inherited from `InjectionModuleBase`:
```csharp
public class TestInjectionModule : InjectionModuleBase
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient<ISomeService,SomeService>;
    }
}
```

- After that you need to call `ServiceLoader.Load` in your `Program.cs` file:
```csharp
var builder = WebApplication.CreateBuilder(args);

ServiceLoader.Load(builder.Services);

var app = builder.Build();
```

So now you can inject this service into your controller and check the result.