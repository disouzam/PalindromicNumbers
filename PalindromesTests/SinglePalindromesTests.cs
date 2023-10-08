using System;

using FluentAssertions;
using FluentAssertions.Execution;

using Palindromes;

using Serilog;
using Serilog.Core;

using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace PalindromesTests;

public class SinglePalindromesTests
{
    private readonly Logger logger;

    private readonly TestOutputHelper logOutput;

    public SinglePalindromesTests(ITestOutputHelper output)
    {
        logOutput = (TestOutputHelper)output;

        Log.Logger = new LoggerConfiguration()
            .WriteTo.TestOutput(logOutput)
            .CreateLogger();

        logger = (Logger)Log.Logger;
    }

    [Theory]
    [InlineData(102, new short[] { 1, 0, 2 })]
    [InlineData(100, new short[] { 1, 0, 0 })]
    [InlineData(120, new short[] { 1, 2, 0 })]
    [InlineData(123, new short[] { 1, 2, 3 })]
    public void GetDigitsShouldReturnAnArrayOfDigits(uint currentNumber, short[] expectedReturn)
    {
        // Arrange
        var arrayLength = expectedReturn.Length;
        var singlePalindromes = new SinglePalindromes(logger);

        // Act
        var currentReturn = singlePalindromes.GetDigits(currentNumber);

        // Assert
        currentReturn.Should().BeEquivalentTo(expectedReturn);

        for (var i = 0; i < arrayLength; i++)
        {
            currentReturn[i].Should().Be(expectedReturn[i]);
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(11)]
    [InlineData(22)]
    [InlineData(33)]
    [InlineData(44)]
    [InlineData(55)]
    [InlineData(66)]
    [InlineData(77)]
    [InlineData(88)]
    [InlineData(99)]
    [InlineData(101)]
    [InlineData(111)]
    [InlineData(121)]
    [InlineData(131)]
    [InlineData(141)]
    [InlineData(151)]
    [InlineData(161)]
    [InlineData(171)]
    [InlineData(181)]
    [InlineData(191)]
    [InlineData(1001)]
    [InlineData(1221)]
    [InlineData(1771)]
    [InlineData(2772)]
    [InlineData(5775)]
    [InlineData(57275)]
    public void CheckValidPalindromeNumbers(uint currentNumber)
    {
        // Arrange
        var singlePalindromes = new SinglePalindromes(logger);

        // Act
        var palindromNumber = singlePalindromes.IsPalindrome(currentNumber);

        // Assert
        palindromNumber.Should().BeTrue();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
    [InlineData(19)]
    [InlineData(20)]
    [InlineData(123)]
    [InlineData(56275)]

    public void CheckInvalidPalindromeNumbers(uint currentNumber)
    {
        // Arrange 
        var singlePalindromes = new SinglePalindromes(logger);

        // Act
        var palindromNumber = singlePalindromes.IsPalindrome(currentNumber);

        // Assert
        palindromNumber.Should().BeFalse();
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(3, 4)]
    [InlineData(4, 5)]
    [InlineData(5, 6)]
    [InlineData(6, 7)]
    [InlineData(7, 8)]
    [InlineData(8, 9)]
    [InlineData(9, 11)]
    [InlineData(11, 22)]
    [InlineData(22, 33)]
    [InlineData(33, 44)]
    [InlineData(44, 55)]
    [InlineData(55, 66)]
    [InlineData(66, 77)]
    [InlineData(77, 88)]
    [InlineData(88, 99)]
    [InlineData(99, 101)]
    [InlineData(101, 111)]
    [InlineData(111, 121)]
    [InlineData(4294884923, 4294884924)]
    public void CheckTheNextLowestPalindrome(uint currentNumber, uint nextPalindrome)
    {
        // Arrange
        var singlePalindromes = new SinglePalindromes(logger);
        uint? nextLowestPalindrome;

        // Act
        nextLowestPalindrome = singlePalindromes.GetLowestNextPalindrome(currentNumber);

        // Assert
        nextLowestPalindrome.Should().Be(nextPalindrome);
    }

    [Fact]
    public void GetLowestNextPalindromeMustThrowOverflowException()
    {
        // Arrange
        var singlePalindromes = new SinglePalindromes(logger);
        uint? nextLowestPalindrome;
        var currentNumber = 4294884924;

        // Act
        var act = () => nextLowestPalindrome = singlePalindromes.GetLowestNextPalindrome(currentNumber);

        // Assert
        act.Should().Throw<OverflowException>();
    }

    [Theory]
    [InlineData(97, new uint[] { 1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 11u, 22u, 33u, 44u, 55u, 66u, 77u, 88u })]
    [InlineData(98, new uint[] { 1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 11u, 22u, 33u, 44u, 55u, 66u, 77u, 88u })]
    [InlineData(99, new uint[] { 1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 11u, 22u, 33u, 44u, 55u, 66u, 77u, 88u, 99u })]
    [InlineData(100, new uint[] { 1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 11u, 22u, 33u, 44u, 55u, 66u, 77u, 88u, 99u })]
    [InlineData(101, new uint[] { 1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 11u, 22u, 33u, 44u, 55u, 66u, 77u, 88u, 99u, 101u })]
    [InlineData(102, new uint[] { 1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 11u, 22u, 33u, 44u, 55u, 66u, 77u, 88u, 99u, 101u })]
    [InlineData(110, new uint[] { 1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 11u, 22u, 33u, 44u, 55u, 66u, 77u, 88u, 99u, 101u })]
    [InlineData(111, new uint[] { 1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 11u, 22u, 33u, 44u, 55u, 66u, 77u, 88u, 99u, 101u, 111u })]
    public void CheckListOfPalindromesInARange(uint maxNumber, uint[] expectedList)
    {
        // Arrange
        var singlePalindromes = new SinglePalindromes(logger);

        // Act
        var currentList = singlePalindromes.GetAllPalindromesInARange(maxNumber);

        // Assert
        currentList.Should().BeEquivalentTo(expectedList);
    }


    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(6, 6)]
    [InlineData(7, 7)]
    [InlineData(8, 8)]
    [InlineData(9, 9)]
    [InlineData(10, 11)]
    [InlineData(11, 22)]
    [InlineData(12, 33)]
    public void CheckNthPalindromes(int position, uint nthPalindrome)
    {
        // Arrange
        uint? currentNthPalindrome;
        var singlePalindromes = new SinglePalindromes(logger);

        // Act
        currentNthPalindrome = singlePalindromes.GetNthPalindrome(position);

        // Assert
        currentNthPalindrome.Should().Be(nthPalindrome);
    }

    [Fact]
    public void CheckLogMessages()
    {
        // Arrange
        var singlePalindromes = new SinglePalindromes(logger);

        // Act
        _ = singlePalindromes.GetNthPalindrome(100);
        var outputContent = logOutput.Output.Split(Environment.NewLine);

        // Assert
        using (new AssertionScope())
        {
            logOutput.Output.Should().NotBeNullOrEmpty();
            outputContent.Length.Should().Be(8);
            outputContent[0].Substring(15).Should().Be("Starting GetNthPalindrome for 100");
            outputContent[1].Substring(15).Should().Be("CurrentPalindrome: 1 - Maximum value for uint: 4294967295");
            outputContent[2].Substring(15).Should().Be("1th Palindrome is: 1");
            outputContent[3].Substring(15).Should().Be("A quarter of processing for 24 has been completed - Current palindrome: 151...");
            outputContent[4].Substring(15).Should().Be("Half of processing for 49 has been completed - Current palindrome: 404...");
            outputContent[5].Substring(15).Should().Be("Three quarters of processing for 74 have been completed - Current palindrome: 656...");
            outputContent[6].Substring(15).Should().Be("Finished GetNthPalindrome for 100 - Palindrome is: 919");
        }
    }

    [Fact]
    public void CheckLogMessages2()
    {
        // Arrange
        var singlePalindromes = new SinglePalindromes(logger);

        // Act
        _ = singlePalindromes.GetNthPalindrome(99);
        var outputContent = logOutput.Output.Split(Environment.NewLine);

        // Assert
        using (new AssertionScope())
        {
            logOutput.Output.Should().NotBeNullOrEmpty();
            outputContent.Length.Should().Be(8);
            outputContent[0].Substring(15).Should().Be("Starting GetNthPalindrome for 99");
            outputContent[1].Substring(15).Should().Be("CurrentPalindrome: 1 - Maximum value for uint: 4294967295");
            outputContent[2].Substring(15).Should().Be("1th Palindrome is: 1");
            outputContent[3].Substring(15).Should().Be("A quarter of processing for 23 has been completed - Current palindrome: 141...");
            outputContent[4].Substring(15).Should().Be("Half of processing for 48 has been completed - Current palindrome: 393...");
            outputContent[5].Substring(15).Should().Be("Three quarters of processing for 73 have been completed - Current palindrome: 646...");
            outputContent[6].Substring(15).Should().Be("Finished GetNthPalindrome for 99 - Palindrome is: 909");
        }
    }

    [Fact]
    public void GetNthPalindromeShouldThrowException()
    {
        // Arrange
        var singlePalindromes = new SinglePalindromes(logger);

        // Act
        var act = () => singlePalindromes.GetNthPalindrome(142947);

        // Assert
        using (new AssertionScope())
        {
            act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("Specified argument was out of the range of valid values. (Parameter 'The maximum palindrome that this program is able to calculate is 4294884924 at 142946th position')");
            logOutput.Output.Should().NotBeNullOrEmpty();
            var outputContent = logOutput.Output.Split(Environment.NewLine);
            outputContent.Length.Should().Be(3);
            outputContent[1].Substring(15).Should().Be("The maximum palindrome that this program is able to calculate is 4294884924 at 142946th position");
        }
    }
}
