using System.Reflection;
using Example01.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Example01.App;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, Settings settings)
    {
        var implementationTypes = Directory.EnumerateFiles(settings.PluginsPath, settings.PluginsPattern)
            .Select(Assembly.LoadFrom)
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass)
            .ToList();

        foreach (var implementationType in implementationTypes)
        {
            foreach(var interfaceType in implementationType.GetInterfaces())
            {
                services.AddSingleton(interfaceType, implementationType);
            }
        }
        
        services.AddSingleton<IPluginManager>(serviceProvider =>
        {
            var plugins = serviceProvider.GetServices<IPlugin>();
            var logger = serviceProvider.GetRequiredService<ILogger<PluginManager>>();
            return new PluginManager(plugins, logger);
        });
        
        return services;
    }
}