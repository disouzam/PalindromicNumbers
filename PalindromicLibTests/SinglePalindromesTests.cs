using FluentAssertions;

using PalindromicLib;

using Xunit;

namespace PalindromicLibTests;

public class SinglePalindromesTests
{
    [Fact]
    public void GetDigitsShouldReturnAnArrayOfDigits()
    {
        // Arrange
        uint currentNumber = 123;
        short[] expectedReturn = { 1, 2, 3};

        // Act
        var currentReturn = SinglePalindromes.GetDigits(currentNumber);

        // Assert
        currentReturn.Should().BeEquivalentTo(expectedReturn);
    }

    [Theory]
    [InlineData(121)]
    public void CheckValidPalindromeNumbers(uint currentNumber)
    {
        // Act
        var palindromNumber = SinglePalindromes.IsPalindrome(currentNumber);

        // Assert
        palindromNumber.Should().BeTrue();
    }

    [Theory]
    [InlineData(123)]
    public void CheckInvalidPalindromeNumbers(uint currentNumber)
    {
        // Act
        var palindromNumber = SinglePalindromes.IsPalindrome(currentNumber);

        // Assert
        palindromNumber.Should().BeFalse();
    }
}