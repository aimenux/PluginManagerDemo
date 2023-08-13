# PluginManagerDemo
```  
Providing a basic manager for loading and running plugins
```  

> In this demo, i m providing a basic manager for loading and running plugins.
>
> :one: `Example01` use [default ioc](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) and some reflection in order to load plugins
>
> :two: `Example02` use [default ioc](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) and [scrutor](https://github.com/khellang/Scrutor) in order to load plugins
>
> :bulb: Plugins are copied on `plugins` folder on post build events and loaded at startup by the application.
>

**`Tools`** : vs22, net 6.0, scrutor, fluent-validation