using System;
using System.Collections.Generic;
using System.IO;

using Palindromes;

using Serilog;

namespace ConsoleApp;

public class FileParserForChallenge12050
{
    private readonly ILogger logger;

    public FileParserForChallenge12050(ILogger logger)
    {
        this.logger = logger.ForContext<FileParserForChallenge12050>();
        logger.Debug("ListOfInputs initialized with {count} elements", ListOfInputs.Count);
        logger.Debug("ListOfOutputs initialized with {count} elements", ListOfOutputs.Count);
    }

    private readonly List<int> listOfInputs = new List<int>();

    public List<int> ListOfInputs
    {
        get
        {
            return listOfInputs;
        }
    }

    private readonly List<uint> listOfOutputs = new List<uint>();

    public List<uint> ListOfOutputs
    {
        get
        {
            return listOfOutputs;
        }
    }

    public void ReadFile(string filePath)
    {
        listOfInputs.Clear();

        using var fileContent = new StreamReader(filePath);
        var lineContent = fileContent.ReadLine();
        var input = Convert.ToInt32(lineContent);

        if (input != 0)
        {
            listOfInputs.Add(input);
        }

        while (!fileContent.EndOfStream && input != 0)
        {
            lineContent = fileContent.ReadLine();
            input = Convert.ToInt32(lineContent);

            if (input != 0)
            {
                listOfInputs.Add(input);
            }
        }

        if (fileContent.EndOfStream)
        {
            logger.Verbose("File was processed until the end.");
        }
        else
        {
            logger.Verbose("File processing was interrupted before end of file due to a zero value found.");
        }

    }

    public void FillListOfOutputs()
    {
        listOfOutputs.Clear();
        var singlePalindromes = new SinglePalindromes(logger);
        uint output;
        var invalidEntries = 0;

        foreach (var input in listOfInputs)
        {
            try
            {
                output = singlePalindromes.GetNthPalindrome(input);
                listOfOutputs.Add(output);
            }
            catch
            {
                logger.Error("{methodName} was not able to get the corresponding {input}th", nameof(FillListOfOutputs), input);
                invalidEntries++;
                
                // Zero will be added as a marker that calculation of Palindrome was not possible for that input and avoid misaligning input and output
                listOfOutputs.Add(0);
            }
        }

        logger.Verbose("Valid entries: {validEntries} - Invalid entries: {invalidEntries}", listOfInputs.Count - invalidEntries, invalidEntries);
    }

    public void WriteOutputFile(string filePath)
    {
        FillListOfOutputs();

        var directoryInfo = Path.GetDirectoryName(filePath);
        _ = Directory.CreateDirectory(directoryInfo);
        var file = File.Create(filePath);
        using var fileContent = new StreamWriter(file);

        foreach (var output in listOfOutputs)
        {
            fileContent.WriteLine(output);
        }

        logger.Verbose("Finished writing output file at {filePath}", filePath);
    }
}
