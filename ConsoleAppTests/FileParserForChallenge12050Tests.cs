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
            fileParser.ListOfInputs.Count.Should().Be(2);
            fileParser.ListOfInputs[0].Should().Be(5);
            fileParser.ListOfInputs[1].Should().Be(7);
        }
    }
}
