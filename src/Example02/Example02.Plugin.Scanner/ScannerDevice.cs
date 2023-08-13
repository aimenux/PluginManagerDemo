using Example02.Core;
using Microsoft.Extensions.Logging;

namespace Example02.Plugin.Scanner;

public class ScannerDevice : IPlugin
{
    private readonly ILogger<ScannerDevice> _logger;

    public ScannerDevice(ILogger<ScannerDevice> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    public void Execute()
    {
        _logger.LogInformation("Scanner device is installed.");
    }
}