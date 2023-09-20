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
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "SampleInput.txt");
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
    }
}
