using System.IO;

using ConsoleApp;

using FluentAssertions;
using FluentAssertions.Execution;

using Xunit;

namespace ConsoleAppTests;

public class FileParserForChallenge12050Tests
{
    [Fact]
    public void CheckReadFileBehaviorWithSampleInput()
    {
        // Arrange
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Samples", "SampleInput.txt");
        var fileParser = new FileParserForChallenge12050();

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
        filePath = Path.Combine(Directory.GetCurrentDirectory(), "Samples", "SampleInput2.txt");

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
        filePath = Path.Combine(Directory.GetCurrentDirectory(), "Samples", "SampleInput3.txt");

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
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Samples", "SampleInput.txt");
        var fileParser = new FileParserForChallenge12050();

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
        filePath = Path.Combine(Directory.GetCurrentDirectory(), "Samples", "SampleInput2.txt");
        fileParser = new FileParserForChallenge12050();

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
        filePath = Path.Combine(Directory.GetCurrentDirectory(), "Samples", "SampleInput3.txt");
        fileParser = new FileParserForChallenge12050();

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
}
