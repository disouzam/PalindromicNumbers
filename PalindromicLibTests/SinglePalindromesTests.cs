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

    [Fact]
    public void CheckValidPalindromeNumbers()
    {
        // Arrange
        uint currentNumber = 121;

        // Act
        var palindromNumber = SinglePalindromes.IsPalindrome(currentNumber);

        // Assert
        palindromNumber.Should().BeTrue();
    }

    [Fact]
    public void CheckInvalidPalindromeNumbers()
    {
        // Arrange
        uint currentNumber = 123;

        // Act
        var palindromNumber = SinglePalindromes.IsPalindrome(currentNumber);

        // Assert
        palindromNumber.Should().BeFalse();
    }
}