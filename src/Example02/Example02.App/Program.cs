using Example02.App;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var settings = configuration
    .GetSection(Settings.SectionName)
    .Get<Settings>()
    .ValidateAndThrow();

var serviceProvider = new ServiceCollection()
    .AddLogging(builder =>
    {
        builder
            .AddFilter("Microsoft", LogLevel.Warning)
            .SetMinimumLevel(LogLevel.Trace)
            .AddConsole();
    })
    .AddServices(settings)
    .BuildServiceProvider();
    
var manager = serviceProvider.GetRequiredService<IPluginManager>();
manager.ListPlugins();
manager.RunPlugins();
