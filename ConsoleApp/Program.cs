using System;
using System.IO;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using Serilog;

namespace ConsoleApp;

public static class Program
{
    private static ILogger logger;

    static void Main(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();
        Startup.BuildConfig(configurationBuilder);

        Log.Logger = new LoggerConfiguration()
                         .ReadFrom.Configuration(configurationBuilder.Build())                         
                         .CreateLogger();

        _ = Host.CreateDefaultBuilder()
            .UseSerilog()
            .Build();
        
        logger = Log.Logger;
        logger.Information("Console App Starting...");

        Console.WriteLine("Challenge 12050 - Palindrome Number - UVA Online Judge");

        logger.Debug("List of arguments inject: {args}", args);

        if (args.Length > 0 && File.Exists(args[0]))
        {
            var fileParser = new FileParserForChallenge12050(logger);
            fileParser.ReadFile(args[0]);

            if (args.Length == 2)
            {
                Console.WriteLine($"Results will be written to file {args[1]}");
                logger.Verbose("Results will be written to file {fileName}", args[1]);
                fileParser.WriteOutputFile(args[1]);
            }
            else
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "Output.txt");
                Console.WriteLine($"Results will be written to file {filePath}");
                logger.Verbose("Results will be written to file {fileName}", filePath);
                fileParser.WriteOutputFile(filePath);
            }
        }
        else
        {
            logger.Error("No file was processed.");
        }

        logger.Information("Console App Finishing...");

        Log.CloseAndFlush();
    }
}
