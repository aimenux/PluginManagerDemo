using System.Reflection;
using Example02.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Example02.App;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, Settings settings)
    {
        var assemblies = Directory.EnumerateFiles(settings.PluginsPath, settings.PluginsPattern)
            .Select(Assembly.LoadFrom)
            .ToList();
        
        foreach (var assembly in assemblies)
        {
            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses()
                .AsImplementedInterfaces()
                .WithSingletonLifetime());
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