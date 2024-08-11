[![.NET](https://github.com/aimenux/PluginManagerDemo/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/aimenux/PluginManagerDemo/actions/workflows/ci.yml)

# PluginManagerDemo
```  
Providing a basic implementation for loading and running plugins
```  

> In this demo, i m providing a basic implementation for loading and running plugins.
>
> :one: `Example01` use [default ioc](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) and some reflection in order to load plugins
>
> :two: `Example02` use [default ioc](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) and [scrutor](https://github.com/khellang/Scrutor) in order to load plugins
>
> In order to run the demo, type those commands in your terminal :
> - dotnet run --project .\src\Example01\Example01.App
> - dotnet run --project .\src\Example02\Example02.App
>
> :bulb: Plugins are copied on `plugins` folder on post build events and loaded at startup by the application.
>
> 
**`Tools`** : net 8.0, scrutor, fluent-validation