using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ConsoleApp;

using FluentAssertions;
using FluentAssertions.Execution;

using Serilog;
using Serilog.Core;

using Xunit;

namespace ConsoleAppTests;

public class FileParserForChallenge12050Tests
{
    private const string samplesFolder = "Samples";
    private const string resultsFolder = "TestResults";

    private readonly string[] sampleFileNames = new[] { "SampleInput.txt", "SampleInput2.txt", "SampleInput3.txt" };
    private readonly string[] resultFileNames = new[] { "Output1.txt", "Output2.txt", "Output3.txt" };

    private readonly Logger logger = new LoggerConfiguration().CreateLogger();

    [Fact]
    public void CheckReadFileBehaviorWithSampleInput()
    {
        // Arrange
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), samplesFolder, sampleFileNames[0]);
        var fileParser = new FileParserForChallenge12050(logger);

        // Act
        fileParser.ReadFile(filePath);

        // Assert
        using (new AssertionScope())
        {
            fileParser.ListOfInputs.Count.Should().Be(3);
            fileParser.ListOfInputs[0].Should().Be(1);
            fileParser.ListOfInputs[1].Should().Be(12);
            fileParser.ListOfInputs[2].Should().Be(24);
        }

        // New Arrangement
        filePath = Path.Combine(Directory.GetCurrentDirectory(), samplesFolder, sampleFileNames[1]);

        // New Act
        fileParser.ReadFile(filePath);

        // New Assertions
        using (new AssertionScope())
        {
            fileParser.ListOfInputs.Count.Should().Be(2);
            fileParser.ListOfInputs[0].Should().Be(5);
            fileParser.ListOfInputs[1].Should().Be(7);
        }

        //Arrangement for a third sample file with zero before end of stream
        filePath = Path.Combine(Directory.GetCurrentDirectory(), samplesFolder, sampleFileNames[2]);

        // Third act
        fileParser.ReadFile(filePath);

        // Third set of Assertions
        using (new AssertionScope())
        {
            fileParser.ListOfInputs.Count.Should().Be(3);
            fileParser.ListOfInputs[0].Should().Be(10);
            fileParser.ListOfInputs[1].Should().Be(20);
            fileParser.ListOfInputs[2].Should().Be(15);
        }
    }

    [Fact]
    public void CheckFillListOfOutputsBehavior()
    {
        // Arrange
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), samplesFolder, sampleFileNames[0]);
        var fileParser = new FileParserForChallenge12050(logger);

        // Act
        fileParser.ReadFile(filePath);
        fileParser.FillListOfOutputs();

        // Assert
        using (new AssertionScope())
        {
            fileParser.ListOfOutputs.Count.Should().Be(3);
            fileParser.ListOfOutputs[0].Should().Be(1);
            fileParser.ListOfOutputs[1].Should().Be(33);
            fileParser.ListOfOutputs[2].Should().Be(151);
        }

        // Arrange for SampleInput2
        filePath = Path.Combine(Directory.GetCurrentDirectory(), samplesFolder, sampleFileNames[1]);

        // Act for SampleInput2
        fileParser.ReadFile(filePath);
        fileParser.FillListOfOutputs();

        // Assert for SampleInput2
        using (new AssertionScope())
        {
            fileParser.ListOfOutputs.Count.Should().Be(2);
            fileParser.ListOfOutputs[0].Should().Be(5);
            fileParser.ListOfOutputs[1].Should().Be(7);
        }

        // Arrange for SampleInput3
        filePath = Path.Combine(Directory.GetCurrentDirectory(), samplesFolder, sampleFileNames[2]);

        // Act for SampleInput3
        fileParser.ReadFile(filePath);
        fileParser.FillListOfOutputs();

        // Assert for SampleInput3
        using (new AssertionScope())
        {
            fileParser.ListOfOutputs.Count.Should().Be(3);
            fileParser.ListOfOutputs[0].Should().Be(11);
            fileParser.ListOfOutputs[1].Should().Be(111);
            fileParser.ListOfOutputs[2].Should().Be(66);
        }
    }

    [Fact]
    public void CheckWriteOutputFileBehaviorWithSampleInputs()
    {
        // Arrange for Sample Input 1
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), samplesFolder, sampleFileNames[0]);
        var fileParser = new FileParserForChallenge12050(logger);

        // Act for Sample Input 1
        fileParser.ReadFile(filePath);

        var output1File = Path.Combine(Directory.GetCurrentDirectory(), resultsFolder, resultFileNames[0]);
        fileParser.WriteOutputFile(output1File);

        // Assert for Sample Input 1
        File.Exists(output1File).Should().Be(true);
        var listOfOutputs1 = ReadOutputFile(output1File);

        using (new AssertionScope())
        {
            listOfOutputs1.Count.Should().Be(3);
            listOfOutputs1[0].Should().Be(1);
            listOfOutputs1[1].Should().Be(33);
            listOfOutputs1[2].Should().Be(151);
        }

        // Arrange for Sample Input 2
        filePath = Path.Combine(Directory.GetCurrentDirectory(), samplesFolder, sampleFileNames[1]);
        fileParser = new FileParserForChallenge12050(logger);

        // Act for Sample Input 2
        fileParser.ReadFile(filePath);

        var output2File = Path.Combine(Directory.GetCurrentDirectory(), resultsFolder, resultFileNames[1]);
        fileParser.WriteOutputFile(output2File);

        // Assert for Sample Input 2
        File.Exists(output2File).Should().Be(true);
        var listOfOutputs2 = ReadOutputFile(output2File);

        using (new AssertionScope())
        {
            listOfOutputs2.Count.Should().Be(2);
            listOfOutputs2[0].Should().Be(5);
            listOfOutputs2[1].Should().Be(7);
        }

        // Arrange for Sample Input 3
        filePath = Path.Combine(Directory.GetCurrentDirectory(), samplesFolder, sampleFileNames[2]);
        fileParser = new FileParserForChallenge12050(logger);

        // Act for Sample Input 3
        fileParser.ReadFile(filePath);

        var output3File = Path.Combine(Directory.GetCurrentDirectory(), resultsFolder, resultFileNames[2]);
        fileParser.WriteOutputFile(output3File);

        // Assert for Sample Input 3
        File.Exists(output3File).Should().Be(true);
        var listOfOutputs3 = ReadOutputFile(output3File);

        using (new AssertionScope())
        {
            listOfOutputs3.Count.Should().Be(3);
            listOfOutputs3[0].Should().Be(11);
            listOfOutputs3[1].Should().Be(111);
            listOfOutputs3[2].Should().Be(66);
        }

        // Delete all output files and folder
        if (File.Exists(output1File))
        {
            File.Delete(output1File);
        }

        if (File.Exists(output2File))
        {
            File.Delete(output2File);
        }

        if (File.Exists(output3File))
        {
            File.Delete(output3File);
        }

        Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), resultsFolder)).Should().BeTrue();
        if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), resultsFolder)))
        {
            Directory.EnumerateFiles(Path.Combine(Directory.GetCurrentDirectory(), resultsFolder)).Count().Should().Be(0);
            Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), resultsFolder));
        }

        using (new AssertionScope())
        {
            File.Exists(output1File).Should().Be(false);
            File.Exists(output2File).Should().Be(false);
            File.Exists(output3File).Should().Be(false);
        }
    }

    private static List<uint> ReadOutputFile(string filePath)
    {
        var listOfOutputs = new List<uint>();

        using var fileContent = new StreamReader(filePath);
        var lineContent = fileContent.ReadLine();
        var output = Convert.ToUInt32(lineContent);

        listOfOutputs.Add(output);

        while (!fileContent.EndOfStream)
        {
            lineContent = fileContent.ReadLine();
            output = Convert.ToUInt32(lineContent);

            listOfOutputs.Add(output);
        }

        return listOfOutputs;
    }
}
