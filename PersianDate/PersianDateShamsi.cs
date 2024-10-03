using System;
using System.Globalization;

namespace PersianDate;

/// <summary>
/// Provides methods to convert Gregorian dates to Persian (Shamsi) dates.
/// <example>
/// <code>
/// var persianDate = new PersianDateShamsi();
/// var shamsiYear = persianDate.GetShamsiYear(new DateTime(2023, 3, 21)); // 1402
/// var shortShamsiYear = persianDate.GetShortShamsiYear(new DateTime(2023, 3, 21)); // "02"
/// var shamsiMonth = persianDate.GetShamsiMonth(new DateTime(2023, 3, 21)); // 1
/// var shamsiDay = persianDate.GetShamsiDay(new DateTime(2023, 3, 21)); // 1
/// </code>
/// </example>
/// </summary>
public class PersianDateShamsi
{
    private readonly PersianCalendar persianCalendar;

    /// <summary>
    /// Initializes a new instance of the <see cref="PersianDateShamsi"/> class.
    /// </summary>
    public PersianDateShamsi()
    {
        persianCalendar = new PersianCalendar();
    }

    /// <summary>
    /// Gets the Shamsi year from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// int? shamsiYear = persianDate.GetShamsiYear(new DateTime(2023, 3, 21)); // Returns 1402
    /// int? nullYear = persianDate.GetShamsiYear(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The Gregorian date.</param>
    /// <returns>The Shamsi year, or null if the input is null or out of range.</returns>
    public int? GetShamsiYear(DateTime? dateTime)
    {
        if (!dateTime.HasValue)
        {
            return null;
        }

        try
        {
            return persianCalendar.GetYear(dateTime.Value);
        }
        catch (ArgumentOutOfRangeException)
        {
            return null;
        }
    }

    /// <summary>
    /// Gets the Shamsi year from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// int? shamsiYear = persianDate.GetShamsiYear(new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero)); // Returns 1402
    /// int? nullYear = persianDate.GetShamsiYear(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The Gregorian date.</param>
    /// <returns>The Shamsi year, or null if the input is null or out of range.</returns>
    public int? GetShamsiYear(DateTimeOffset? dateTimeOffset)
    {
        return GetShamsiYear(dateTimeOffset?.DateTime);
    }

    /// <summary>
    /// Gets the short Shamsi year from the specified Gregorian date as a string.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shortShamsiYear = persianDate.GetShortShamsiYear(new DateTime(2023, 3, 21)); // Returns "02"
    /// string? nullYear = persianDate.GetShortShamsiYear(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The Gregorian date.</param>
    /// <returns>The short Shamsi year as a string, or null if the input is null.</returns>
    public string? GetShortShamsiYear(DateTime? dateTime)
    {
        return dateTime?.ToString("yy", CultureInfo.CreateSpecificCulture("fa"));
    }

    /// <summary>
    /// Gets the short Shamsi year from the specified Gregorian date as a string.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shortShamsiYear = persianDate.GetShortShamsiYear(new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero)); // Returns "02"
    /// string? nullYear = persianDate.GetShortShamsiYear(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The Gregorian date.</param>
    /// <returns>The short Shamsi year as a string, or null if the input is null.</returns>
    public string? GetShortShamsiYear(DateTimeOffset? dateTimeOffset)
    {
        return GetShortShamsiYear(dateTimeOffset?.DateTime);
    }

    /// <summary>
    /// Gets the Shamsi year from the specified Gregorian date as a string.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shamsiYearString = persianDate.GetShamsiYearToString(new DateTime(2023, 3, 21)); // Returns "1402"
    /// string? nullYear = persianDate.GetShamsiYearToString(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The Gregorian date.</param>
    /// <returns>The Shamsi year as a string, or null if the input is null or out of range.</returns>
    public string? GetShamsiYearToString(DateTime? dateTime)
    {
        if (!dateTime.HasValue)
        {
            return null;
        }

        try
        {
            return persianCalendar.GetYear(dateTime.Value).ToString();
        }
        catch (ArgumentOutOfRangeException)
        {
            return null;
        }
    }

    /// <summary>
    /// Gets the Shamsi year from the specified Gregorian date as a string.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shamsiYearString = persianDate.GetShamsiYearToString(new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero)); // Returns "1402"
    /// string? nullYear = persianDate.GetShamsiYearToString(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The Gregorian date.</param>
    /// <returns>The Shamsi year as a string, or null if the input is null or out of range.</returns>
    public string? GetShamsiYearToString(DateTimeOffset? dateTimeOffset)
    {
        return GetShamsiYearToString(dateTimeOffset?.DateTime);
    }

    /// <summary>
    /// Gets the Shamsi month from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// int? shamsiMonth = persianDate.GetShamsiMonth(new DateTime(2023, 3, 21)); // Returns 1
    /// int? nullMonth = persianDate.GetShamsiMonth(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The Gregorian date.</param>
    /// <returns>The Shamsi month, or null if the input is null.</returns>
    public int? GetShamsiMonth(DateTime? dateTime)
    {
        return dateTime.HasValue ? persianCalendar.GetMonth(dateTime.Value) : null;
    }

    /// <summary>
    /// Gets the Shamsi month from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// int? shamsiMonth = persianDate.GetShamsiMonth(new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero)); // Returns 1
    /// int? nullMonth = persianDate.GetShamsiMonth(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The Gregorian date.</param>
    /// <returns>The Shamsi month, or null if the input is null.</returns>
    public int? GetShamsiMonth(DateTimeOffset? dateTimeOffset)
    {
        return GetShamsiMonth(dateTimeOffset?.DateTime);
    }

    /// <summary>
    /// Gets the Shamsi month number from the specified Gregorian date as a string.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string shamsiMonthString = persianDate.GetShamsiMonthString(new DateTime(2023, 3, 21)); // Returns "01"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The Gregorian date.</param>
    /// <returns>The Shamsi month number as a string.</returns>
    public string GetShamsiMonthString(DateTime dateTime)
    {
        return persianCalendar.GetMonth(dateTime).ToString("00");
    }

    /// <summary>
    /// Gets the Shamsi month number from the specified Gregorian date as a string.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string shamsiMonthString = persianDate.GetShamsiMonthString(new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero)); // Returns "01"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The Gregorian date.</param>
    /// <returns>The Shamsi month number as a string.</returns>
    public string GetShamsiMonthString(DateTimeOffset dateTimeOffset)
    {
        return GetShamsiMonthString(dateTimeOffset.DateTime);
    }

    /// <summary>
    /// Gets the Shamsi month number from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// int? shamsiMonthNumber = persianDate.GetShamsiMonthNumber(new DateTime(2023, 3, 21)); // Returns 1
    /// int? nullMonth = persianDate.GetShamsiMonthNumber(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The Gregorian date.</param>
    /// <returns>The Shamsi month number, or null if the input is null.</returns>
    public int? GetShamsiMonthNumber(DateTime? dateTime)
    {
        return dateTime.HasValue ? persianCalendar.GetMonth(dateTime.Value) : null;
    }

    /// <summary>
    /// Gets the Shamsi month number from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// int? shamsiMonthNumber = persianDate.GetShamsiMonthNumber(new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero)); // Returns 1
    /// int? nullMonth = persianDate.GetShamsiMonthNumber(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The Gregorian date.</param>
    /// <returns>The Shamsi month number, or null if the input is null.</returns>
    public int? GetShamsiMonthNumber(DateTimeOffset? dateTimeOffset)
    {
        return GetShamsiMonthNumber(dateTimeOffset?.DateTime);
    }

    /// <summary>
    /// Gets the Shamsi month name from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shamsiMonthName = persianDate.GetShamsiMonthName(new DateTime(2023, 3, 21)); // Returns "فروردین"
    /// string? nullMonth = persianDate.GetShamsiMonthName(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The Gregorian date.</param>
    /// <returns>The Shamsi month name, or null if the input is null.</returns>
    public string? GetShamsiMonthName(DateTime? dateTime)
    {
        return dateTime?.ToString("MMMM", CultureInfo.CreateSpecificCulture("fa"));
    }

    /// <summary>
    /// Gets the Shamsi month name from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shamsiMonthName = persianDate.GetShamsiMonthName(new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero)); // Returns "فروردین"
    /// string? nullMonth = persianDate.GetShamsiMonthName(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The Gregorian date.</param>
    /// <returns>The Shamsi month name, or null if the input is null.</returns>
    public string? GetShamsiMonthName(DateTimeOffset? dateTimeOffset)
    {
        return GetShamsiMonthName(dateTimeOffset?.DateTime);
    }

    /// <summary>
    /// Gets the Shamsi day from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// int? shamsiDay = persianDate.GetShamsiDay(new DateTime(2023, 3, 21)); // Returns 1
    /// int? nullDay = persianDate.GetShamsiDay(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The Gregorian date.</param>
    /// <returns>The Shamsi day, or null if the input is null.</returns>
    public int? GetShamsiDay(DateTime? dateTime)
    {
        return dateTime.HasValue ? persianCalendar.GetDayOfMonth(dateTime.Value) : null;
    }

    /// <summary>
    /// Gets the Shamsi day from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// int? shamsiDay = persianDate.GetShamsiDay(new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero)); // Returns 1
    /// int? nullDay = persianDate.GetShamsiDay(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The Gregorian date.</param>
    /// <returns>The Shamsi day, or null if the input is null.</returns>
    public int? GetShamsiDay(DateTimeOffset? dateTimeOffset)
    {
        return GetShamsiDay(dateTimeOffset?.DateTime);
    }

    /// <summary>
    /// Gets the Shamsi day from the specified Gregorian date as a string.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shamsiDayString = persianDate.GetShamsiDayString(new DateTime(2023, 3, 21)); // Returns "01"
    /// string? nullDay = persianDate.GetShamsiDayString(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The Gregorian date.</param>
    /// <returns>The Shamsi day as a string, or null if the input is null.</returns>
    public string? GetShamsiDayString(DateTime? dateTime)
    {
        return dateTime.HasValue ? persianCalendar.GetDayOfMonth(dateTime.Value).ToString("00") : null;
    }

    /// <summary>
    /// Gets the Shamsi day from the specified Gregorian date as a string.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shamsiDayString = persianDate.GetShamsiDayString(new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero)); // Returns "01"
    /// string? nullDay = persianDate.GetShamsiDayString(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The Gregorian date.</param>
    /// <returns>The Shamsi day as a string, or null if the input is null.</returns>
    public string? GetShamsiDayString(DateTimeOffset? dateTimeOffset)
    {
        return GetShamsiDayString(dateTimeOffset?.DateTime);
    }

    /// <summary>
    /// Gets the Shamsi day name from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shamsiDayName = persianDate.GetShamsiDayName(new DateTime(2023, 3, 21)); // Returns "سه‌شنبه"
    /// string? nullDay = persianDate.GetShamsiDayName(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The Gregorian date.</param>
    /// <returns>The Shamsi day name, or null if the input is null.</returns>
    public string? GetShamsiDayName(DateTime? dateTime)
    {
        return dateTime?.ToString("dddd", CultureInfo.CreateSpecificCulture("fa"));
    }

    /// <summary>
    /// Gets the Shamsi day name from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shamsiDayName = persianDate.GetShamsiDayName(new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero)); // Returns "سه‌شنبه"
    /// string? nullDay = persianDate.GetShamsiDayName(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The Gregorian date.</param>
    /// <returns>The Shamsi day name, or null if the input is null.</returns>
    public string? GetShamsiDayName(DateTimeOffset? dateTimeOffset)
    {
        return GetShamsiDayName(dateTimeOffset?.DateTime);
    }

    /// <summary>
    /// Gets the short Shamsi day name from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shortShamsiDayName = persianDate.GetShamsiDayShortName(new DateTime(2023, 3, 21)); // Returns "س"
    /// string? nullDay = persianDate.GetShamsiDayShortName(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTime">The Gregorian date.</param>
    /// <returns>The short Shamsi day name, or null if the input is null.</returns>
    public string? GetShamsiDayShortName(DateTime? dateTime)
    {
        return (dateTime?.ToString("dddd", CultureInfo.CreateSpecificCulture("fa")))?[..1];
    }

    /// <summary>
    /// Gets the short Shamsi day name from the specified Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new PersianDateShamsi();
    /// string? shortShamsiDayName = persianDate.GetShamsiDayShortName(new DateTimeOffset(2023, 3, 21, 0, 0, 0, TimeSpan.Zero)); // Returns "س"
    /// string? nullDay = persianDate.GetShamsiDayShortName(null); // Returns null
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="dateTimeOffset">The Gregorian date.</param>
    /// <returns>The short Shamsi day name, or null if the input is null.</returns>
    public string? GetShamsiDayShortName(DateTimeOffset? dateTimeOffset)
    {
        return GetShamsiDayShortName(dateTimeOffset?.DateTime);
    }
}
