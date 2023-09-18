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
}