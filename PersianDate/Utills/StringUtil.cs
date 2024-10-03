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
    /// <summary>
    /// Removes diacritical marks from Persian characters.
    /// <example>
    /// <code>
    /// string normalizedString = StringUtil.RemoveDiacritics("مَدرَسِه"); // Returns "مدرسه"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The string without diacritical marks.</returns>
    public static string RemoveDiacritics(string input)
    {
        string[] diacritics = { "\u064B", "\u064C", "\u064D", "\u064E", "\u064F", "\u0650", "\u0651", "\u0652" };
        foreach (string diacritic in diacritics)
        {
            input = input.Replace(diacritic, string.Empty);
        }
        return input;
    }

    /// <summary>
    /// Converts Arabic numbers to Persian numbers in a string.
    /// <example>
    /// <code>
    /// string persianNumbers = StringUtil.NormalizePersianNumbers("123٤٥٦"); // Returns "۱۲۳۴۵۶"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The string with Persian numbers.</returns>
    public static string NormalizePersianNumbers(string input)
    {
        return input
            .Replace('0', '۰')
            .Replace('1', '۱')
            .Replace('2', '۲')
            .Replace('3', '۳')
            .Replace('4', '۴')
            .Replace('5', '۵')
            .Replace('6', '۶')
            .Replace('7', '۷')
            .Replace('8', '۸')
            .Replace('9', '۹')
            .Replace('٤', '۴')
            .Replace('٥', '۵')
            .Replace('٦', '۶');
    }

    /// <summary>
    /// Checks if a character is a Persian letter.
    /// <example>
    /// <code>
    /// bool isPersian = StringUtil.IsPersianLetter('م'); // Returns true
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="input">The input character.</param>
    /// <returns>True if the character is a Persian letter; otherwise, false.</returns>
    public static bool IsPersianLetter(char input)
    {
        return input is >= '\u0600' and <= '\u06FF';
    }
}
