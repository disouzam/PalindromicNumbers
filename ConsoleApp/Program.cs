using System;
using System.IO;

namespace ConsoleApp;

public static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Challenge 12050 - Palindrome Number - UVA Online Judge");

        if (args.Length > 0 && File.Exists(args[0]))
        {
            var fileParser = new FileParserForChallenge12050();
            fileParser.ReadFile(args[0]);

            if (args.Length == 2)
            {
                Console.WriteLine($"Results will be written to file {args[1]}");
                fileParser.WriteOutputFile(args[1]);
            }
            else
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "Output.txt");
                Console.WriteLine($"Results will be written to file {filePath}");
                fileParser.WriteOutputFile(filePath);
            }
        }
    }
}
