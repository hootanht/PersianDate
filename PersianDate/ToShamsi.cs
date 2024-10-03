using System;

namespace PersianDate;

/// <summary>
/// Provides extension methods to convert Gregorian dates to Persian (Shamsi) dates.
/// </summary>
public static class ToShamsi
{
    /// <summary>
    /// Get Shamsi Date From Miladi Year
    /// Example:
    /// <code>
    /// DateTime? dateTime = new DateTime(2023, 10, 5);
    /// string? shamsiDate = dateTime.ToShamsiDate(); // "1402/07/13"
    /// </code>
    /// </summary>
    /// <param name="dateTime">Enter The Jalali DateTime</param>
    /// <returns>A string representing the Shamsi date or null if the input is null.</returns>
    public static string? ToShamsiDate(this DateTime? dateTime)
    {
        if (!dateTime.HasValue)
        {
            return null;
        }

        PersianDateShamsi persianDateShamsi = new();
        return persianDateShamsi.GetShamsiYearToString(dateTime) + "/" + persianDateShamsi.GetShamsiMonthString(dateTime.Value) + "/" + persianDateShamsi.GetShamsiDayString(dateTime.Value);
    }

    /// <summary>
    /// Get Shamsi Date From Miladi Year
    /// Example:
    /// <code>
    /// DateTimeOffset? dateTimeOffset = new DateTimeOffset(2023, 10, 5, 0, 0, 0, TimeSpan.Zero);
    /// string? shamsiDate = dateTimeOffset.ToShamsiDate(); // "1402/07/13"
    /// </code>
    /// </summary>
    /// <param name="dateTimeOffset">Enter The Jalali DateTimeOffset</param>
    /// <returns>A string representing the Shamsi date or null if the input is null.</returns>
    public static string? ToShamsiDate(this DateTimeOffset? dateTimeOffset)
    {
        if (!dateTimeOffset.HasValue)
        {
            return null;
        }

        PersianDateShamsi persianDateShamsi = new();
        return persianDateShamsi.GetShamsiYearToString(dateTimeOffset) + "/" + persianDateShamsi.GetShamsiMonthString(dateTimeOffset.Value) + "/" + persianDateShamsi.GetShamsiDayString(dateTimeOffset.Value);
    }

    /// <summary>
    /// Get Short Shamsi Date From Miladi Year
    /// Example:
    /// <code>
    /// DateTime? dateTime = new DateTime(2023, 10, 5);
    /// string? shortShamsiDate = dateTime.ToShortShamsiDate(); // "02/07/13"
    /// </code>
    /// </summary>
    /// <param name="dateTime">Enter The Jalali DateTime</param>
    /// <returns>A string representing the short Shamsi date or null if the input is null.</returns>
    public static string? ToShortShamsiDate(this DateTime? dateTime)
    {
        if (!dateTime.HasValue)
        {
            return null;
        }

        PersianDateShamsi persianDateShamsi = new();
        return persianDateShamsi.GetShortShamsiYear(dateTime) + "/" + persianDateShamsi.GetShamsiMonthString(dateTime.Value) + "/" + persianDateShamsi.GetShamsiDayString(dateTime.Value);
    }

    /// <summary>
    /// Get Short Shamsi Date From Miladi Year
    /// Example:
    /// <code>
    /// DateTimeOffset? dateTimeOffset = new DateTimeOffset(2023, 10, 5, 0, 0, 0, TimeSpan.Zero);
    /// string? shortShamsiDate = dateTimeOffset.ToShortShamsiDate(); // "02/07/13"
    /// </code>
    /// </summary>
    /// <param name="dateTimeOffset">Enter The Jalali DateTimeOffset</param>
    /// <returns>A string representing the short Shamsi date or null if the input is null.</returns>
    public static string? ToShortShamsiDate(this DateTimeOffset? dateTimeOffset)
    {
        if (!dateTimeOffset.HasValue)
        {
            return null;
        }

        PersianDateShamsi persianDateShamsi = new();
        return persianDateShamsi.GetShortShamsiYear(dateTimeOffset) + "/" + persianDateShamsi.GetShamsiMonthString(dateTimeOffset.Value) + "/" + persianDateShamsi.GetShamsiDayString(dateTimeOffset.Value);
    }

    /// <summary>
    /// Get Long Shamsi Date From Miladi Year
    /// Example:
    /// <code>
    /// DateTime? dateTime = new DateTime(2023, 10, 5);
    /// string? longShamsiDate = dateTime.ToLongShamsiDate(); // "پنجشنبه 13 مهر 1402"
    /// </code>
    /// </summary>
    /// <param name="dateTime">Enter The Jalali DateTime</param>
    /// <returns>A string representing the long Shamsi date or null if the input is null.</returns>
    public static string? ToLongShamsiDate(this DateTime? dateTime)
    {
        if (!dateTime.HasValue)
        {
            return null;
        }

        PersianDateShamsi persianDateShamsi = new();
        return persianDateShamsi.GetShamsiDayName(dateTime) + " " + persianDateShamsi.GetShamsiDay(dateTime) + " " + persianDateShamsi.GetShamsiMonthName(dateTime) + " " + persianDateShamsi.GetShamsiYear(dateTime);
    }

    /// <summary>
    /// Get Long Shamsi Date From Miladi Year
    /// Example:
    /// <code>
    /// DateTimeOffset? dateTimeOffset = new DateTimeOffset(2023, 10, 5, 0, 0, 0, TimeSpan.Zero);
    /// string? longShamsiDate = dateTimeOffset.ToLongShamsiDate(); // "پنجشنبه 13 مهر 1402"
    /// </code>
    /// </summary>
    /// <param name="dateTimeOffset">Enter The Jalali DateTimeOffset</param>
    /// <returns>A string representing the long Shamsi date or null if the input is null.</returns>
    public static string? ToLongShamsiDate(this DateTimeOffset? dateTimeOffset)
    {
        if (!dateTimeOffset.HasValue)
        {
            return null;
        }

        PersianDateShamsi persianDateShamsi = new();
        return persianDateShamsi.GetShamsiDayName(dateTimeOffset) + " " + persianDateShamsi.GetShamsiDay(dateTimeOffset) + " " + persianDateShamsi.GetShamsiMonthName(dateTimeOffset) + " " + persianDateShamsi.GetShamsiYear(dateTimeOffset);
    }
}
