﻿using Serilog;

namespace Devv.Gateway.Api.Logging;

public static class ConfigureServices
{
    public static void AddLogging(this ConfigureHostBuilder host, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        host.UseSerilog(Log.Logger);
    }
}