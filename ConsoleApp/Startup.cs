using System;
using System.IO;

using Microsoft.Extensions.Configuration;

namespace ConsoleApp;

internal static class Startup
{
    internal static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("consoleapp.settings.json", false, true)
               .AddJsonFile($"consoleapp.settings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
               .AddEnvironmentVariables();
    }
}
