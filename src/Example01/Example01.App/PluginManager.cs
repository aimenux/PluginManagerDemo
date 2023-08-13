using Example01.Core;
using Microsoft.Extensions.Logging;

namespace Example01.App;

public interface IPluginManager
{
    void ListPlugins();
    void RunPlugins();
}

public class PluginManager : IPluginManager
{
    private readonly IReadOnlyCollection<IPlugin> _plugins;
    private readonly ILogger<PluginManager> _logger;

    public PluginManager(IEnumerable<IPlugin> plugins, ILogger<PluginManager> logger)
    {
        _plugins = Array.AsReadOnly(plugins?.ToArray() ?? Array.Empty<IPlugin>());
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void ListPlugins()
    {
        _logger.LogInformation("Found {count} plugins.", _plugins.Count);

        foreach (var plugin in _plugins)
        {
            _logger.LogInformation("Found plugin '{name}'.", plugin.GetType().Name);
        }
    }

    public void RunPlugins()
    {
        foreach (var plugin in _plugins)
        {
            try
            {
                plugin.Execute();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured when running plugin '{name}'.", plugin.GetType().Name);
            }
        }
    }
}