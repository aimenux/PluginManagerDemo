﻿using Example02.Core;
using Microsoft.Extensions.Logging;

namespace Example02.Plugin.Printer;

public class PrinterDevice : IPlugin
{
    private readonly ILogger<PrinterDevice> _logger;

    public PrinterDevice(ILogger<PrinterDevice> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Execute()
    {
        _logger.LogInformation("Printer device is installed.");
    }
}