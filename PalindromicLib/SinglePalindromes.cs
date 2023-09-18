using System.Collections.Generic;
using System.Linq;

namespace PalindromicLib;

/// <summary>
/// This class contain methods to check if a given number (in base 10) is a palindrome or not
/// </summary>
public static class SinglePalindromes
{
    public static bool IsPalindrome(uint number)
    {
        // to be implemented
    }

    public static short[] GetDigits(uint number)
    {
        var digits = new List<short>();
        var remainder = number;
        uint currentDigit;

        while (remainder > 0) 
        {
            currentDigit = remainder % 10;
            remainder = remainder / 10;
            digits.Add((short)currentDigit);
        }

        digits.Reverse();

        return digits.ToArray();
    }
}