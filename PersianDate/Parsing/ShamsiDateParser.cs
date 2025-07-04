using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PersianDate.Parsing;

/// <summary>
/// Provides parsing and validation functionality for Persian/Shamsi dates.
/// </summary>
public static class ShamsiDateParser
{
    private static readonly Dictionary<string, int> PersianMonthNumbers = new()
    {
        { "فروردین", 1 }, { "اردیبهشت", 2 }, { "خرداد", 3 },
        { "تیر", 4 }, { "مرداد", 5 }, { "شهریور", 6 },
        { "مهر", 7 }, { "آبان", 8 }, { "آذر", 9 },
        { "دی", 10 }, { "بهمن", 11 }, { "اسفند", 12 }
    };

    private static readonly Dictionary<string, string> PersianToArabicDigits = new()
    {
        { "۰", "0" }, { "۱", "1" }, { "۲", "2" }, { "۳", "3" }, { "۴", "4" },
        { "۵", "5" }, { "۶", "6" }, { "۷", "7" }, { "۸", "8" }, { "۹", "9" }
    };

    /// <summary>
    /// Parses a Persian date string to DateTime.
    /// </summary>
    /// <param name="persianDateString">The Persian date string (e.g., "1402/01/15", "15 فروردین 1402").</param>
    /// <returns>The parsed DateTime.</returns>
    /// <exception cref="FormatException">Thrown when the format is invalid.</exception>
    /// <exception cref="ArgumentException">Thrown when the date is invalid.</exception>
    public static DateTime Parse(string persianDateString)
    {
        if (TryParse(persianDateString, out DateTime result))
        {
            return result;
        }

        throw new FormatException($"Unable to parse '{persianDateString}' as a valid Persian date.");
    }

    /// <summary>
    /// Tries to parse a Persian date string to DateTime.
    /// </summary>
    /// <param name="persianDateString">The Persian date string.</param>
    /// <param name="result">The parsed DateTime if successful.</param>
    /// <returns>True if parsing was successful; otherwise, false.</returns>
    public static bool TryParse(string persianDateString, out DateTime result)
    {
        result = default;

        if (string.IsNullOrWhiteSpace(persianDateString))
            return false;

        // Convert Persian digits to Arabic numerals
        string normalizedInput = ConvertPersianDigitsToArabic(persianDateString.Trim());

        // Try different parsing patterns
        return TryParseNumericFormat(normalizedInput, out result) ||
               TryParseTextualFormat(normalizedInput, out result) ||
               TryParseISOFormat(normalizedInput, out result) ||
               TryParseMixedFormat(normalizedInput, out result);
    }

    /// <summary>
    /// Validates if a Persian date is valid without parsing.
    /// </summary>
    /// <param name="year">The Shamsi year.</param>
    /// <param name="month">The Shamsi month.</param>
    /// <param name="day">The Shamsi day.</param>
    /// <returns>True if the date is valid; otherwise, false.</returns>
    public static bool IsValidShamsiDate(int year, int month, int day)
    {
        try
        {
            var pc = new PersianCalendar();
            
            // Check basic ranges
            if (year < pc.MinSupportedDateTime.Year || year > pc.MaxSupportedDateTime.Year)
                return false;
            
            if (month < 1 || month > 12)
                return false;
            
            if (day < 1)
                return false;

            // Check day is valid for the specific month and year
            int maxDaysInMonth = GetDaysInShamsiMonth(year, month);
            return day <= maxDaysInMonth;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Gets the number of days in a specific Shamsi month and year.
    /// </summary>
    /// <param name="year">The Shamsi year.</param>
    /// <param name="month">The Shamsi month.</param>
    /// <returns>The number of days in the month.</returns>
    public static int GetDaysInShamsiMonth(int year, int month)
    {
        var pc = new PersianCalendar();
        return pc.GetDaysInMonth(year, month);
    }

    /// <summary>
    /// Parses a Persian date string and validates it.
    /// </summary>
    /// <param name="persianDateString">The Persian date string.</param>
    /// <param name="strictValidation">Whether to perform strict validation.</param>
    /// <returns>A validation result containing the parsed date and validation status.</returns>
    public static ShamsiDateValidationResult ParseAndValidate(string persianDateString, bool strictValidation = true)
    {
        var result = new ShamsiDateValidationResult
        {
            IsValid = false,
            Input = persianDateString
        };

        if (string.IsNullOrWhiteSpace(persianDateString))
        {
            result.ErrorMessage = "Input cannot be null or empty.";
            return result;
        }

        try
        {
            if (TryParse(persianDateString, out DateTime parsedDate))
            {
                result.IsValid = true;
                result.ParsedDate = parsedDate;
                
                if (strictValidation)
                {
                    // Additional validations for strict mode
                    var pc = new PersianCalendar();
                    int year = pc.GetYear(parsedDate);
                    int month = pc.GetMonth(parsedDate);
                    int day = pc.GetDayOfMonth(parsedDate);
                    
                    if (!IsValidShamsiDate(year, month, day))
                    {
                        result.IsValid = false;
                        result.ErrorMessage = "Date is not a valid Shamsi date.";
                    }
                }
            }
            else
            {
                result.ErrorMessage = "Unable to parse the date string.";
            }
        }
        catch (Exception ex)
        {
            result.ErrorMessage = ex.Message;
        }

        return result;
    }

    /// <summary>
    /// Converts a Gregorian date to Shamsi and validates it.
    /// </summary>
    /// <param name="gregorianDate">The Gregorian date.</param>
    /// <returns>Shamsi date components if valid.</returns>
    public static ShamsiDateComponents ToShamsiComponents(DateTime gregorianDate)
    {
        var pc = new PersianCalendar();
        
        return new ShamsiDateComponents
        {
            Year = pc.GetYear(gregorianDate),
            Month = pc.GetMonth(gregorianDate),
            Day = pc.GetDayOfMonth(gregorianDate),
            DayOfWeek = pc.GetDayOfWeek(gregorianDate),
            DayOfYear = pc.GetDayOfYear(gregorianDate),
            IsLeapYear = pc.IsLeapYear(pc.GetYear(gregorianDate))
        };
    }

    private static bool TryParseNumericFormat(string input, out DateTime result)
    {
        result = default;

        // Pattern: yyyy/MM/dd or yyyy-MM-dd or yyyy.MM.dd
        var numericPattern = @"^(\d{4})[\/\-\.](\d{1,2})[\/\-\.](\d{1,2})$";
        var match = Regex.Match(input, numericPattern);

        if (match.Success &&
            int.TryParse(match.Groups[1].Value, out int year) &&
            int.TryParse(match.Groups[2].Value, out int month) &&
            int.TryParse(match.Groups[3].Value, out int day))
        {
            if (IsValidShamsiDate(year, month, day))
            {
                var pc = new PersianCalendar();
                result = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                return true;
            }
        }

        return false;
    }

    private static bool TryParseTextualFormat(string input, out DateTime result)
    {
        result = default;

        // Pattern: "dd MonthName yyyy" or "MonthName yyyy"
        foreach (var monthName in PersianMonthNumbers.Keys)
        {
            if (input.Contains(monthName))
            {
                // Extract numbers from the string
                var numbers = Regex.Matches(input, @"\d+");
                
                if (numbers.Count >= 2) // day and year
                {
                    if (int.TryParse(numbers[0].Value, out int day) &&
                        int.TryParse(numbers[1].Value, out int year))
                    {
                        int month = PersianMonthNumbers[monthName];
                        
                        if (IsValidShamsiDate(year, month, day))
                        {
                            var pc = new PersianCalendar();
                            result = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                            return true;
                        }
                    }
                }
                else if (numbers.Count == 1) // only year, assume day 1
                {
                    if (int.TryParse(numbers[0].Value, out int year))
                    {
                        int month = PersianMonthNumbers[monthName];
                        int day = 1;
                        
                        if (IsValidShamsiDate(year, month, day))
                        {
                            var pc = new PersianCalendar();
                            result = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    private static bool TryParseISOFormat(string input, out DateTime result)
    {
        result = default;

        // Pattern: yyyy-MM-dd (strict ISO format)
        var isoPattern = @"^(\d{4})-(\d{2})-(\d{2})$";
        var match = Regex.Match(input, isoPattern);

        if (match.Success &&
            int.TryParse(match.Groups[1].Value, out int year) &&
            int.TryParse(match.Groups[2].Value, out int month) &&
            int.TryParse(match.Groups[3].Value, out int day))
        {
            if (IsValidShamsiDate(year, month, day))
            {
                var pc = new PersianCalendar();
                result = pc.ToDateTime(year, month, day, 0, 0, 0, 0);
                return true;
            }
        }

        return false;
    }

    private static bool TryParseMixedFormat(string input, out DateTime result)
    {
        result = default;

        // Handle various mixed formats
        var patterns = new[]
        {
            @"(\d{1,2})\s*/\s*(\d{1,2})\s*/\s*(\d{4})", // dd/MM/yyyy
            @"(\d{4})\s*/\s*(\d{1,2})\s*/\s*(\d{1,2})", // yyyy/MM/dd
            @"(\d{1,2})\s*-\s*(\d{1,2})\s*-\s*(\d{4})",  // dd-MM-yyyy
            @"(\d{4})\s*-\s*(\d{1,2})\s*-\s*(\d{1,2})"   // yyyy-MM-dd
        };

        foreach (var pattern in patterns)
        {
            var match = Regex.Match(input, pattern);
            if (match.Success)
            {
                var values = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    if (!int.TryParse(match.Groups[i + 1].Value, out values[i]))
                        break;
                }

                // Try different date component arrangements
                var arrangements = new[]
                {
                    new { Year = values[2], Month = values[1], Day = values[0] }, // dd/MM/yyyy
                    new { Year = values[0], Month = values[1], Day = values[2] }  // yyyy/MM/dd
                };

                foreach (var arr in arrangements)
                {
                    if (IsValidShamsiDate(arr.Year, arr.Month, arr.Day))
                    {
                        var pc = new PersianCalendar();
                        result = pc.ToDateTime(arr.Year, arr.Month, arr.Day, 0, 0, 0, 0);
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private static string ConvertPersianDigitsToArabic(string input)
    {
        string result = input;
        foreach (var kvp in PersianToArabicDigits)
        {
            result = result.Replace(kvp.Key, kvp.Value);
        }
        return result;
    }
}

/// <summary>
/// Represents the result of Shamsi date validation.
/// </summary>
public class ShamsiDateValidationResult
{
    /// <summary>Gets or sets whether the date is valid.</summary>
    public bool IsValid { get; set; }
    
    /// <summary>Gets or sets the parsed DateTime if valid.</summary>
    public DateTime? ParsedDate { get; set; }
    
    /// <summary>Gets or sets the original input string.</summary>
    public string Input { get; set; } = string.Empty;
    
    /// <summary>Gets or sets the error message if validation failed.</summary>
    public string ErrorMessage { get; set; } = string.Empty;
}

/// <summary>
/// Represents Shamsi date components.
/// </summary>
public class ShamsiDateComponents
{
    /// <summary>Gets or sets the Shamsi year.</summary>
    public int Year { get; set; }
    
    /// <summary>Gets or sets the Shamsi month.</summary>
    public int Month { get; set; }
    
    /// <summary>Gets or sets the Shamsi day.</summary>
    public int Day { get; set; }
    
    /// <summary>Gets or sets the day of week.</summary>
    public DayOfWeek DayOfWeek { get; set; }
    
    /// <summary>Gets or sets the day of year.</summary>
    public int DayOfYear { get; set; }
    
    /// <summary>Gets or sets whether the year is a leap year.</summary>
    public bool IsLeapYear { get; set; }
}
