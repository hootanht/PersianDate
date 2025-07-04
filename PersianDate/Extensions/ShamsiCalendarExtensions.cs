using System;
using System.Collections.Generic;
using PersianDate.Culture;
using PersianDate.Formatting;

namespace PersianDate.Extensions;

/// <summary>
/// Provides extension methods for DateTime to access Shamsi calendar operations.
/// </summary>
public static class ShamsiCalendarExtensions
{
    private static readonly ShamsiCalendarOperations CalendarOps = new();

    /// <summary>
    /// Determines if the Shamsi year of the specified date is a leap year.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2024, 3, 20); // 1403 (leap year)
    /// bool isLeap = date.IsShamsiLeapYear(); // Returns true
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>True if the Shamsi year is a leap year; otherwise, false.</returns>
    public static bool IsShamsiLeapYear(this DateTime date)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        int shamsiYear = persianCalendar.GetYear(date);
        return CalendarOps.IsLeapYear(shamsiYear);
    }

    /// <summary>
    /// Gets the number of days in the Shamsi month of the specified date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 3, 21); // 1 Farvardin 1402
    /// int days = date.GetShamsiDaysInMonth(); // Returns 31
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>The number of days in the Shamsi month.</returns>
    public static int GetShamsiDaysInMonth(this DateTime date)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        int shamsiYear = persianCalendar.GetYear(date);
        int shamsiMonth = persianCalendar.GetMonth(date);
        return CalendarOps.GetDaysInMonth(shamsiYear, shamsiMonth);
    }

    /// <summary>
    /// Gets the number of days in the Shamsi year of the specified date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2024, 3, 20); // 1403 (leap year)
    /// int days = date.GetShamsiDaysInYear(); // Returns 366
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>The number of days in the Shamsi year.</returns>
    public static int GetShamsiDaysInYear(this DateTime date)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        int shamsiYear = persianCalendar.GetYear(date);
        return CalendarOps.GetDaysInYear(shamsiYear);
    }

    /// <summary>
    /// Gets the Nowruz (Persian New Year) date for the Shamsi year of the specified date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 6, 15); // Any date in 1402
    /// DateTime nowruz = date.GetShamsiNewYearDate(); // Returns 2023-03-21 (1 Farvardin 1402)
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to get the New Year date for.</param>
    /// <returns>The Nowruz date for the Shamsi year.</returns>
    public static DateTime GetShamsiNewYearDate(this DateTime date)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        int shamsiYear = persianCalendar.GetYear(date);
        return CalendarOps.GetNewYearDate(shamsiYear);
    }

    /// <summary>
    /// Gets the first day of the Shamsi month for the specified date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 4, 15); // Any day in Ordibehesht 1402
    /// DateTime firstDay = date.GetShamsiFirstDayOfMonth(); // Returns first day of Ordibehesht
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to get the first day of month for.</param>
    /// <returns>The first day of the Shamsi month.</returns>
    public static DateTime GetShamsiFirstDayOfMonth(this DateTime date)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        int shamsiYear = persianCalendar.GetYear(date);
        int shamsiMonth = persianCalendar.GetMonth(date);
        return CalendarOps.GetFirstDayOfMonth(shamsiYear, shamsiMonth);
    }

    /// <summary>
    /// Gets the last day of the Shamsi month for the specified date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 4, 15); // Any day in Ordibehesht 1402
    /// DateTime lastDay = date.GetShamsiLastDayOfMonth(); // Returns last day of Ordibehesht
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to get the last day of month for.</param>
    /// <returns>The last day of the Shamsi month.</returns>
    public static DateTime GetShamsiLastDayOfMonth(this DateTime date)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        int shamsiYear = persianCalendar.GetYear(date);
        int shamsiMonth = persianCalendar.GetMonth(date);
        return CalendarOps.GetLastDayOfMonth(shamsiYear, shamsiMonth);
    }

    /// <summary>
    /// Gets all dates in the Shamsi month of the specified date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 3, 25); // Any day in Farvardin 1402
    /// List&lt;DateTime&gt; dates = date.GetShamsiDatesInMonth(); // Returns all 31 dates in Farvardin
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to get the month dates for.</param>
    /// <returns>A list of all dates in the Shamsi month.</returns>
    public static List<DateTime> GetShamsiDatesInMonth(this DateTime date)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        int shamsiYear = persianCalendar.GetYear(date);
        int shamsiMonth = persianCalendar.GetMonth(date);
        return CalendarOps.GetDatesInMonth(shamsiYear, shamsiMonth);
    }

    /// <summary>
    /// Gets all dates in the Shamsi year of the specified date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 6, 15); // Any date in 1402
    /// List&lt;DateTime&gt; dates = date.GetShamsiDatesInYear(); // Returns all 365 dates in 1402
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to get the year dates for.</param>
    /// <returns>A list of all dates in the Shamsi year.</returns>
    public static List<DateTime> GetShamsiDatesInYear(this DateTime date)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        int shamsiYear = persianCalendar.GetYear(date);
        return CalendarOps.GetDatesInYear(shamsiYear);
    }

    /// <summary>
    /// Adds the specified number of Shamsi months to the date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 3, 21); // 1 Farvardin 1402
    /// DateTime newDate = date.AddShamsiMonths(3); // Adds 3 Shamsi months
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The base date.</param>
    /// <param name="months">The number of months to add (can be negative).</param>
    /// <returns>A new DateTime with the months added.</returns>
    public static DateTime AddShamsiMonths(this DateTime date, int months)
    {
        return CalendarOps.AddShamsiMonths(date, months);
    }

    /// <summary>
    /// Adds the specified number of Shamsi years to the date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 3, 21); // 1 Farvardin 1402
    /// DateTime newDate = date.AddShamsiYears(5); // Adds 5 Shamsi years
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The base date.</param>
    /// <param name="years">The number of years to add (can be negative).</param>
    /// <returns>A new DateTime with the years added.</returns>
    public static DateTime AddShamsiYears(this DateTime date, int years)
    {
        return CalendarOps.AddShamsiYears(date, years);
    }

    /// <summary>
    /// Gets the Shamsi season for the specified date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 3, 21); // 1 Farvardin 1402
    /// string season = date.GetShamsiSeason(); // Returns "بهار"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>The Persian name of the season.</returns>
    public static string GetShamsiSeason(this DateTime date)
    {
        return CalendarOps.GetSeason(date);
    }

    /// <summary>
    /// Gets the week number within the Shamsi year for the specified date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2023, 3, 28); // Around 7 Farvardin 1402
    /// int week = date.GetShamsiWeekOfYear(); // Returns week number
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>The week number within the Shamsi year.</returns>
    public static int GetShamsiWeekOfYear(this DateTime date)
    {
        return CalendarOps.GetWeekOfYear(date);
    }

    /// <summary>
    /// Gets the number of days between two dates.
    /// <example>
    /// <code>
    /// DateTime date1 = new DateTime(2023, 3, 21);
    /// DateTime date2 = new DateTime(2023, 3, 28);
    /// int days = date1.GetDaysUntil(date2); // Returns 7
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns>The number of days between the dates (positive if endDate is after startDate).</returns>
    public static int GetDaysUntil(this DateTime startDate, DateTime endDate)
    {
        return CalendarOps.GetDaysBetween(startDate, endDate);
    }

    /// <summary>
    /// Gets all dates between two dates (inclusive).
    /// <example>
    /// <code>
    /// DateTime start = new DateTime(2023, 3, 21);
    /// DateTime end = new DateTime(2023, 3, 25);
    /// List&lt;DateTime&gt; dates = start.GetDateRangeUntil(end); // Returns 5 dates
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns>A list of DateTime objects representing all dates in the range.</returns>
    /// <exception cref="ArgumentException">Thrown when the start date is after the end date.</exception>
    public static List<DateTime> GetDateRangeUntil(this DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
        {
            throw new ArgumentException("Start date cannot be after end date.");
        }

        List<DateTime> dates = [];
        for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
        {
            dates.Add(date);
        }

        return dates;
    }

    /// <summary>
    /// Formats the DateTime as a Shamsi date string using the specified format.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2024, 3, 20);
    /// string formatted = date.ToShamsiFormattedString("yyyy/MM/dd"); // Returns "1403/01/01"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <param name="format">The format pattern.</param>
    /// <param name="usePersianDigits">Whether to use Persian digits.</param>
    /// <returns>The formatted Shamsi date string.</returns>
    public static string ToShamsiFormattedString(this DateTime date, string format, bool usePersianDigits = true)
    {
        return ShamsiDateFormatter.Format(date, format, usePersianDigits);
    }

    /// <summary>
    /// Formats the DateTime as a Shamsi date string using a predefined style.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2024, 3, 20);
    /// string formatted = date.ToShamsiFormattedString(ShamsiDateFormatStyle.Long); // Returns formatted long date
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to format.</param>
    /// <param name="style">The formatting style.</param>
    /// <param name="usePersianDigits">Whether to use Persian digits.</param>
    /// <returns>The formatted Shamsi date string.</returns>
    public static string ToShamsiFormattedString(this DateTime date, ShamsiDateFormatStyle style, bool usePersianDigits = true)
    {
        return ShamsiDateFormatter.Format(date, style, usePersianDigits);
    }

    /// <summary>
    /// Gets the Persian month name for the Shamsi month of the specified date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2024, 3, 20);
    /// string monthName = date.GetShamsiMonthName(); // Returns "فروردین"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to get the month name for.</param>
    /// <returns>The Persian month name.</returns>
    public static string GetShamsiMonthName(this DateTime date)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        int month = persianCalendar.GetMonth(date);
        return ShamsiDateFormatter.GetPersianMonthName(month);
    }

    /// <summary>
    /// Gets the Persian day name for the specified date.
    /// <example>
    /// <code>
    /// DateTime date = new DateTime(2024, 3, 20);
    /// string dayName = date.GetShamsiDayName(); // Returns day name in Persian
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to get the day name for.</param>
    /// <returns>The Persian day name.</returns>
    public static string GetShamsiDayName(this DateTime date)
    {
        var persianCalendar = new System.Globalization.PersianCalendar();
        DayOfWeek dayOfWeek = persianCalendar.GetDayOfWeek(date);
        return ShamsiDateFormatter.GetPersianDayName(dayOfWeek);
    }
}

/// <summary>
/// Provides extension methods for DateTimeOffset to access Shamsi calendar operations.
/// </summary>
public static class ShamsiCalendarExtensionsForOffset
{
    /// <summary>
    /// Determines if the Shamsi year of the specified DateTimeOffset is a leap year.
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2024, 3, 20, 0, 0, 0, TimeSpan.Zero);
    /// bool isLeap = date.IsShamsiLeapYear(); // Returns true
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to check.</param>
    /// <returns>True if the Shamsi year is a leap year; otherwise, false.</returns>
    public static bool IsShamsiLeapYear(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.DateTime.IsShamsiLeapYear();
    }

    /// <summary>
    /// Gets the number of days in the Shamsi month of the specified DateTimeOffset.
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero);
    /// int days = date.GetShamsiDaysInMonth(); // Returns 31
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to check.</param>
    /// <returns>The number of days in the Shamsi month.</returns>
    public static int GetShamsiDaysInMonth(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.DateTime.GetShamsiDaysInMonth();
    }

    /// <summary>
    /// Gets the number of days in the Shamsi year of the specified DateTimeOffset.
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2024, 3, 20, 0, 0, 0, TimeSpan.Zero);
    /// int days = date.GetShamsiDaysInYear(); // Returns 366
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to check.</param>
    /// <returns>The number of days in the Shamsi year.</returns>
    public static int GetShamsiDaysInYear(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.DateTime.GetShamsiDaysInYear();
    }

    /// <summary>
    /// Gets the Shamsi season for the specified DateTimeOffset.
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero);
    /// string season = date.GetShamsiSeason(); // Returns "بهار"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to check.</param>
    /// <returns>The Persian name of the season.</returns>
    public static string GetShamsiSeason(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.DateTime.GetShamsiSeason();
    }

    /// <summary>
    /// Adds the specified number of Shamsi months to the DateTimeOffset.
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2023, 3, 21, 12, 0, 0, TimeSpan.Zero);
    /// DateTimeOffset newDate = date.AddShamsiMonths(3); // Adds 3 Shamsi months
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The base DateTimeOffset.</param>
    /// <param name="months">The number of months to add (can be negative).</param>
    /// <returns>A new DateTimeOffset with the months added.</returns>
    public static DateTimeOffset AddShamsiMonths(this DateTimeOffset dateTimeOffset, int months)
    {
        DateTime newDateTime = dateTimeOffset.DateTime.AddShamsiMonths(months);
        return new DateTimeOffset(newDateTime, dateTimeOffset.Offset);
    }

    /// <summary>
    /// Adds the specified number of Shamsi years to the DateTimeOffset.
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2023, 3, 21, 12, 0, 0, TimeSpan.Zero);
    /// DateTimeOffset newDate = date.AddShamsiYears(5); // Adds 5 Shamsi years
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The base DateTimeOffset.</param>
    /// <param name="years">The number of years to add (can be negative).</param>
    /// <returns>A new DateTimeOffset with the years added.</returns>
    public static DateTimeOffset AddShamsiYears(this DateTimeOffset dateTimeOffset, int years)
    {
        DateTime newDateTime = dateTimeOffset.DateTime.AddShamsiYears(years);
        return new DateTimeOffset(newDateTime, dateTimeOffset.Offset);
    }

    /// <summary>
    /// Formats the DateTimeOffset as a Shamsi date string using the specified format.
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2024, 3, 20, 12, 0, 0, TimeSpan.Zero);
    /// string formatted = date.ToShamsiFormattedString("yyyy/MM/dd"); // Returns "1403/01/01"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to format.</param>
    /// <param name="format">The format pattern.</param>
    /// <param name="usePersianDigits">Whether to use Persian digits.</param>
    /// <returns>The formatted Shamsi date string.</returns>
    public static string ToShamsiFormattedString(this DateTimeOffset dateTimeOffset, string format, bool usePersianDigits = true)
    {
        return dateTimeOffset.DateTime.ToShamsiFormattedString(format, usePersianDigits);
    }

    /// <summary>
    /// Formats the DateTimeOffset as a Shamsi date string using a predefined style.
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2024, 3, 20, 12, 0, 0, TimeSpan.Zero);
    /// string formatted = date.ToShamsiFormattedString(ShamsiDateFormatStyle.Long); // Returns formatted long date
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to format.</param>
    /// <param name="style">The formatting style.</param>
    /// <param name="usePersianDigits">Whether to use Persian digits.</param>
    /// <returns>The formatted Shamsi date string.</returns>
    public static string ToShamsiFormattedString(this DateTimeOffset dateTimeOffset, ShamsiDateFormatStyle style, bool usePersianDigits = true)
    {
        return dateTimeOffset.DateTime.ToShamsiFormattedString(style, usePersianDigits);
    }

    /// <summary>
    /// Gets the Persian month name for the Shamsi month of the specified DateTimeOffset.
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2024, 3, 20, 12, 0, 0, TimeSpan.Zero);
    /// string monthName = date.GetShamsiMonthName(); // Returns "فروردین"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to get the month name for.</param>
    /// <returns>The Persian month name.</returns>
    public static string GetShamsiMonthName(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.DateTime.GetShamsiMonthName();
    }

    /// <summary>
    /// Gets the Persian day name for the specified DateTimeOffset.
    /// <example>
    /// <code>
    /// DateTimeOffset date = new DateTimeOffset(2024, 3, 20, 12, 0, 0, TimeSpan.Zero);
    /// string dayName = date.GetShamsiDayName(); // Returns day name in Persian
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The DateTimeOffset to get the day name for.</param>
    /// <returns>The Persian day name.</returns>
    public static string GetShamsiDayName(this DateTimeOffset dateTimeOffset)
    {
        return dateTimeOffset.DateTime.GetShamsiDayName();
    }
}
