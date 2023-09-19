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
        Assert.Equal(expectedReturn, currentReturn);
    }

    [Fact]
    public void CheckValidPalindromeNumbers()
    {
        // Arrange
        uint currentNumber = 121;

        // Act
        var palindromNumber = SinglePalindromes.IsPalindrome(currentNumber);

        // Assert
        Assert.True(palindromNumber);
    }

    [Fact]
    public void CheckInvalidPalindromeNumbers()
    {
        // Arrange
        uint currentNumber = 123;

        // Act
        var palindromNumber = SinglePalindromes.IsPalindrome(currentNumber);

        // Assert
        Assert.False(palindromNumber);
    }
}