using System;
using System.IO;

using Microsoft.Extensions.Configuration;

namespace ConsoleApp;

internal static class Startup
{
    internal static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("Settings\\consoleapp.settings.json", false, true)
               .AddJsonFile($"Settings\\consoleapp.settings.{Environment.GetEnvironmentVariable("CONSOLE_ENVIRONMENT") ?? "Production"}.json", true)
               .AddEnvironmentVariables();
    }
}
