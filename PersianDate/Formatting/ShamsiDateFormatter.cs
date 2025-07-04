using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PersianDate.Formatting;

/// <summary>
/// Provides enhanced formatting options for Persian/Shamsi dates.
/// </summary>
public class ShamsiDateFormatter
{
    private static readonly Dictionary<string, string> PersianMonths = new()
    {
        { "01", "فروردین" }, { "02", "اردیبهشت" }, { "03", "خرداد" },
        { "04", "تیر" }, { "05", "مرداد" }, { "06", "شهریور" },
        { "07", "مهر" }, { "08", "آبان" }, { "09", "آذر" },
        { "10", "دی" }, { "11", "بهمن" }, { "12", "اسفند" }
    };

    private static readonly Dictionary<string, string> PersianDaysOfWeek = new()
    {
        { "Saturday", "شنبه" }, { "Sunday", "یکشنبه" }, { "Monday", "دوشنبه" },
        { "Tuesday", "سه‌شنبه" }, { "Wednesday", "چهارشنبه" }, { "Thursday", "پنج‌شنبه" },
        { "Friday", "جمعه" }
    };

    private static readonly Dictionary<string, string> PersianDigits = new()
    {
        { "0", "۰" }, { "1", "۱" }, { "2", "۲" }, { "3", "۳" }, { "4", "۴" },
        { "5", "۵" }, { "6", "۶" }, { "7", "۷" }, { "8", "۸" }, { "9", "۹" }
    };

    /// <summary>
    /// Formats a DateTime using custom Persian patterns.
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <param name="format">The format pattern (e.g., "yyyy/MM/dd", "MMMM yyyy", "dddd dd MMMM yyyy").</param>
    /// <param name="usePersianDigits">Whether to use Persian digits instead of Arabic numerals.</param>
    /// <returns>The formatted Persian date string.</returns>
    public static string Format(DateTime date, string format, bool usePersianDigits = true)
    {
        var pc = new PersianCalendar();
        int year = pc.GetYear(date);
        int month = pc.GetMonth(date);
        int day = pc.GetDayOfMonth(date);
        DayOfWeek dayOfWeek = pc.GetDayOfWeek(date);

        string result = format;

        // Replace year patterns
        result = result.Replace("yyyy", year.ToString("0000"));
        result = result.Replace("yy", (year % 100).ToString("00"));

        // Replace month patterns
        result = result.Replace("MMMM", PersianMonths[month.ToString("00")]);
        result = result.Replace("MMM", PersianMonths[month.ToString("00")]);
        result = result.Replace("MM", month.ToString("00"));
        result = result.Replace("M", month.ToString());

        // Replace day patterns
        result = result.Replace("dddd", PersianDaysOfWeek[dayOfWeek.ToString()]);
        result = result.Replace("ddd", PersianDaysOfWeek[dayOfWeek.ToString()]);
        result = result.Replace("dd", day.ToString("00"));
        result = result.Replace("d", day.ToString());

        // Convert to Persian digits if requested
        if (usePersianDigits)
        {
            result = ConvertToPersianDigits(result);
        }

        return result;
    }

    /// <summary>
    /// Formats a DateTime with predefined format styles.
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <param name="style">The formatting style.</param>
    /// <param name="usePersianDigits">Whether to use Persian digits.</param>
    /// <returns>The formatted Persian date string.</returns>
    public static string Format(DateTime date, ShamsiDateFormatStyle style, bool usePersianDigits = true)
    {
        string pattern = style switch
        {
            ShamsiDateFormatStyle.Short => "yyyy/MM/dd",
            ShamsiDateFormatStyle.Medium => "dd MMMM yyyy",
            ShamsiDateFormatStyle.Long => "dddd dd MMMM yyyy",
            ShamsiDateFormatStyle.Full => "dddd، dd MMMM yyyy",
            ShamsiDateFormatStyle.YearMonth => "MMMM yyyy",
            ShamsiDateFormatStyle.MonthDay => "dd MMMM",
            ShamsiDateFormatStyle.ISO => "yyyy-MM-dd",
            _ => "yyyy/MM/dd"
        };

        return Format(date, pattern, usePersianDigits);
    }

    /// <summary>
    /// Gets the Persian month name for a given month number.
    /// </summary>
    /// <param name="month">The month number (1-12).</param>
    /// <returns>The Persian month name.</returns>
    public static string GetPersianMonthName(int month)
    {
        if (month < 1 || month > 12)
            throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");

        return PersianMonths[month.ToString("00")];
    }

    /// <summary>
    /// Gets the Persian day of week name.
    /// </summary>
    /// <param name="dayOfWeek">The day of week.</param>
    /// <returns>The Persian day name.</returns>
    public static string GetPersianDayName(DayOfWeek dayOfWeek)
    {
        return PersianDaysOfWeek[dayOfWeek.ToString()];
    }

    /// <summary>
    /// Converts Arabic numerals to Persian digits.
    /// </summary>
    /// <param name="text">The text containing Arabic numerals.</param>
    /// <returns>The text with Persian digits.</returns>
    public static string ConvertToPersianDigits(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        var result = new StringBuilder(text);
        foreach (var kvp in PersianDigits)
        {
            result.Replace(kvp.Key, kvp.Value);
        }

        return result.ToString();
    }

    /// <summary>
    /// Converts Persian digits to Arabic numerals.
    /// </summary>
    /// <param name="text">The text containing Persian digits.</param>
    /// <returns>The text with Arabic numerals.</returns>
    public static string ConvertToArabicDigits(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        var result = new StringBuilder(text);
        foreach (var kvp in PersianDigits)
        {
            result.Replace(kvp.Value, kvp.Key);
        }

        return result.ToString();
    }

    /// <summary>
    /// Formats the time portion of a DateTime in Persian.
    /// </summary>
    /// <param name="date">The DateTime to format.</param>
    /// <param name="format">The time format pattern (e.g., "HH:mm", "HH:mm:ss").</param>
    /// <param name="usePersianDigits">Whether to use Persian digits.</param>
    /// <returns>The formatted time string.</returns>
    public static string FormatTime(DateTime date, string format = "HH:mm", bool usePersianDigits = true)
    {
        string result = date.ToString(format);
        
        if (usePersianDigits)
        {
            result = ConvertToPersianDigits(result);
        }

        return result;
    }

    /// <summary>
    /// Formats both date and time in Persian.
    /// </summary>
    /// <param name="date">The DateTime to format.</param>
    /// <param name="dateStyle">The date formatting style.</param>
    /// <param name="timeFormat">The time format pattern.</param>
    /// <param name="usePersianDigits">Whether to use Persian digits.</param>
    /// <returns>The formatted date and time string.</returns>
    public static string FormatDateTime(DateTime date, ShamsiDateFormatStyle dateStyle = ShamsiDateFormatStyle.Medium, 
        string timeFormat = "HH:mm", bool usePersianDigits = true)
    {
        string dateStr = Format(date, dateStyle, usePersianDigits);
        string timeStr = FormatTime(date, timeFormat, usePersianDigits);
        
        return $"{dateStr} {timeStr}";
    }
}

/// <summary>
/// Defines formatting styles for Shamsi dates.
/// </summary>
public enum ShamsiDateFormatStyle
{
    /// <summary>Short format: 1402/01/01</summary>
    Short,
    /// <summary>Medium format: 01 فروردین 1402</summary>
    Medium,
    /// <summary>Long format: شنبه 01 فروردین 1402</summary>
    Long,
    /// <summary>Full format: شنبه، 01 فروردین 1402</summary>
    Full,
    /// <summary>Year and month: فروردین 1402</summary>
    YearMonth,
    /// <summary>Month and day: 01 فروردین</summary>
    MonthDay,
    /// <summary>ISO format: 1402-01-01</summary>
    ISO
}
