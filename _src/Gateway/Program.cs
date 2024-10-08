using System.Globalization;
using Data;
using Gateway.Data;
using Gateway.Proxy;
using Gateway.FastEndpoints;
using Gateway.Logging;
using Gateway.Configuration;
using Gateway.WebServer;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace Gateway;

public class Program
{
    public static async Task Main(string[] args)
    {
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

        var builder = WebApplication.CreateBuilder(args);
        var host = builder.Host;

        // Clear the default configuration sources
        builder.Configuration.Sources.Clear();
        builder.Configuration.SetBasePath(Environment.GetEnvironmentVariable("CONFIG_PATH"))
            .AddJsonFile("appsettings.json", false, true)
            .AddEnvironmentVariables();

        var configuration = builder.Configuration;

        builder.Services.Configure<EnvironmentOptions>(config =>
        {
            config.CertificatePath = configuration["CERT_PATH"] ?? "/etc/app/certs";
            config.LogsPath = configuration["LOG_PATH"] ?? "/var/log/app";
            config.ConfigPath = configuration["CONFIG_PATH"] ?? "/etc/app-config";
            config.StaticFilesPath = configuration["STATIC_CONTENT_PATH"] ?? "/var/www/app/static";
            config.DataPath = configuration["DATA_PATH"] ?? "/var/lib/app/data";
        });

        host.AddLogging(builder.Configuration);

        builder.Configuration.AddConfigurationSources(args);
        builder.Services.AddLazyCache();
        builder.Services.AddScoped<HostCertificateCache>();
        builder.Services.AddScoped<CertificateManager>();
        builder.WebHost.ConfigureWebServer();
        builder.Services.AddDataContext(configuration);
        builder.Services.AddGatewayHttpsRedirection();
        builder.Services.AddGatewayFastEndpoints();
        builder.Services.AddProxy();
        builder.Services.AddMediator();
        builder.Services.AddHostedService<LoadStartup>();

        var app = builder.Build();

        var envOptions = app.Services.GetRequiredService<IOptions<EnvironmentOptions>>().Value;

        app.UseWhen(context => !IsStaticFileRequest(context), appBuilder => { appBuilder.UseHttpsRedirection(); });
        app.UseAuthorization();
        // Serve static files from the path
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(envOptions.StaticFilesPath),
            RequestPath = $"/{EnvironmentOptions.StaticRequestPath}"
        });

        app.UseGatewayFastEndpoints(configuration);
        app.UseProxy();

        await app.RunAsync();
    }

    private static bool IsStaticFileRequest(HttpContext context)
    {
        return context.Request.Path.StartsWithSegments($"/{EnvironmentOptions.StaticRequestPath}")
               && context.Request.Method == "GET"
               && !context.Request.IsHttps;
    }
}