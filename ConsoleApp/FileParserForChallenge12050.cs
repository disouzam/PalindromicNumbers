using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp;

public class FileParserForChallenge12050
{
    private List<int> listOfInputs = new List<int>();

    public List<int> ListOfInputs
    {
        get
        {
            return listOfInputs;
        }
    }


    public void ReadFile(string filePath)
    {
        using var fileContent = new StreamReader(filePath);

        listOfInputs.Clear();

        while (!fileContent.EndOfStream)
        {
            var lineContent = fileContent.ReadLine();
            var input = Convert.ToInt32(lineContent);

            if (input != 0)
            {
                listOfInputs.Add(input);
            }
            else
            { 
                break; 
            }
        }
    }
}
