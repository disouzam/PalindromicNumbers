using System.Collections.Generic;

using FluentAssertions;

using PalindromicLib;

using Xunit;

namespace PalindromicLibTests;

public class SinglePalindromesTests
{
    [Theory]
    [InlineData(102, new short[]{1, 0, 2})]
    [InlineData(100, new short[]{1, 0, 0})]
    [InlineData(120, new short[]{1, 2, 0})]
    [InlineData(123, new short[]{1, 2, 3})]
    public void GetDigitsShouldReturnAnArrayOfDigits(uint currentNumber, short[] expectedReturn)
    {
        // Arrange
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

    [Theory]
    [InlineData(1,2)]
    [InlineData(2,3)]
    [InlineData(3,4)]
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
    public void CheckTheNextLowestPalindrome(uint currentNumber, uint nextPalindrome)
    {
        // Arrange
        uint? nextLowestPalindrome = null;

        // Act
        nextLowestPalindrome = SinglePalindromes.GetLowestNextPalindrome(currentNumber);

        // Assert
        nextLowestPalindrome.Should().Be(nextPalindrome);
    }

    [Theory]
    [InlineData(99, new uint[] { 1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 11u, 22u, 33u, 44u, 55u, 66u, 77u, 88u, 99u})]
    [InlineData(100, new uint[] { 1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 11u, 22u, 33u, 44u, 55u, 66u, 77u, 88u, 99u})]
    [InlineData(101, new uint[] { 1u, 2u, 3u, 4u, 5u, 6u, 7u, 8u, 9u, 11u, 22u, 33u, 44u, 55u, 66u, 77u, 88u, 99u, 101u})]
    public void CheckListOfPalindromesInARange(uint maxNumber, uint[] expectedList)
    {
        // Arrange

        // Act
        var currentList = SinglePalindromes.GetAllPalindromesInARange(maxNumber);

        // Assert
        currentList.Should().BeEquivalentTo(expectedList);
    }
}