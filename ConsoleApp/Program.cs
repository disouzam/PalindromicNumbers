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
        }
    }
}
