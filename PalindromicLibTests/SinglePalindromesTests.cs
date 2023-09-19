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
        var arrayLength = expectedReturn.Length;

        // Act
        var currentReturn = SinglePalindromes.GetDigits(currentNumber);

        // Assert
        currentReturn.Should().BeEquivalentTo(expectedReturn);

        for ( var i = 0; i < arrayLength; i++)
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
        // Act
        var palindromNumber = SinglePalindromes.IsPalindrome(currentNumber);

        // Assert
        palindromNumber.Should().BeTrue();
    }

    [Theory]
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
        // Act
        var palindromNumber = SinglePalindromes.IsPalindrome(currentNumber);

        // Assert
        palindromNumber.Should().BeFalse();
    }
}