using System;
using System.Collections.Generic;
using System.IO;

using PalindromicLib;

namespace ConsoleApp;

public class FileParserForChallenge12050
{
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
    }

    public void FillListOfOutputs()
    {
        listOfOutputs.Clear();

        foreach (var input in listOfInputs)
        {
            var output = SinglePalindromes.GetNthPalindrome(input);
            listOfOutputs.Add(output);
        }
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
    }
}
