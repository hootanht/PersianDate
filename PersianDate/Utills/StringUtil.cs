using System;
using System.Globalization;
using System.Linq;

namespace PersianDate.Utills;

/// <summary>
/// Provides utility methods for string operations.
/// </summary>
public static class StringUtil
{
    /// <summary>
    /// Converts iOS keyboard and Arabic characters to Persian characters.
    /// <example>
    /// <code>
    /// char persianChar = StringUtil.ConvertToPersianCharacter('ي'); // Returns 'ی'
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="input">The input character.</param>
    /// <returns>The converted Persian character.</returns>
    public static char ConvertToPersianCharacter(char input)
    {
        return input switch
        {
            'ي' => 'ی', // Arabic 'yeh' to Persian 'yeh'
            'ك' => 'ک', // Arabic 'kaf' to Persian 'kaf'
            'ة' => 'ه', // Arabic 'teh marbuta' to Persian 'heh'
            '٤' => '۴', // Arabic '4' to Persian '4'
            '٥' => '۵', // Arabic '5' to Persian '5'
            '٦' => '۶', // Arabic '6' to Persian '6'
            _ => input
        };
    }

    /// <summary>
    /// Converts a string containing iOS keyboard and Arabic characters to Persian characters.
    /// <example>
    /// <code>
    /// string persianString = StringUtil.ConvertToPersianString("يوم"); // Returns "یوم"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The converted Persian string.</returns>
    public static string ConvertToPersianString(string input)
    {
        return new string(input.Select(ConvertToPersianCharacter).ToArray());
    }

    /// <summary>
    /// Checks if a string contains any Persian characters.
    /// <example>
    /// <code>
    /// bool containsPersian = StringUtil.ContainsPersianCharacters("سلام"); // Returns true
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>True if the string contains Persian characters; otherwise, false.</returns>
    public static bool ContainsPersianCharacters(string input)
    {
        return input.Any(c => c is >= '\u0600' and <= '\u06FF');
    }

    /// <summary>
    /// Reverses a string.
    /// <example>
    /// <code>
    /// string reversedString = StringUtil.ReverseString("سلام"); // Returns "مالس"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The reversed string.</returns>
    public static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    /// <summary>
    /// Converts a string to title case.
    /// <example>
    /// <code>
    /// string titleCaseString = StringUtil.ToTitleCase("hello world"); // Returns "Hello World"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The string converted to title case.</returns>
    public static string ToTitleCase(string input)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
    }
}
