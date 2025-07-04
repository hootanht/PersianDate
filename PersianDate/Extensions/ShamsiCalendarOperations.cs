using System;
using System.Collections.Generic;
using System.Globalization;

namespace PersianDate.Extensions;

/// <summary>
/// Provides advanced calendar operations for Persian (Shamsi) dates.
/// <example>
/// <code>
/// var calendarOps = new ShamsiCalendarOperations();
/// bool isLeap = calendarOps.IsLeapYear(1403); // Check if 1403 is a leap year
/// int daysInMonth = calendarOps.GetDaysInMonth(1403, 12); // Get days in Esfand 1403
/// DateTime nowruz = calendarOps.GetNewYearDate(1404); // Get Nowruz date for 1404
/// </code>
/// </example>
/// </summary>
public class ShamsiCalendarOperations
{
    private readonly PersianCalendar persianCalendar;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShamsiCalendarOperations"/> class.
    /// </summary>
    public ShamsiCalendarOperations()
    {
        persianCalendar = new PersianCalendar();
    }

    /// <summary>
    /// Determines whether the specified Shamsi year is a leap year.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// bool isLeap = calendarOps.IsLeapYear(1403); // Returns true if 1403 is a leap year
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year to check.</param>
    /// <returns>True if the year is a leap year; otherwise, false.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the year is outside the supported range.</exception>
    public bool IsLeapYear(int shamsiYear)
    {
        try
        {
            return persianCalendar.IsLeapYear(shamsiYear);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException(nameof(shamsiYear), $"The year {shamsiYear} is outside the supported range for Persian calendar.");
        }
    }

    /// <summary>
    /// Gets the number of days in the specified Shamsi month and year.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// int days = calendarOps.GetDaysInMonth(1403, 12); // Returns 30 for Esfand in a leap year
    /// int days2 = calendarOps.GetDaysInMonth(1402, 12); // Returns 29 for Esfand in a normal year
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <param name="shamsiMonth">The Shamsi month (1-12).</param>
    /// <returns>The number of days in the specified month.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the year or month is outside the valid range.</exception>
    public int GetDaysInMonth(int shamsiYear, int shamsiMonth)
    {
        if (shamsiMonth < 1 || shamsiMonth > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(shamsiMonth), "Month must be between 1 and 12.");
        }

        try
        {
            return persianCalendar.GetDaysInMonth(shamsiYear, shamsiMonth);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException(nameof(shamsiYear), $"The year {shamsiYear} is outside the supported range for Persian calendar.");
        }
    }

    /// <summary>
    /// Gets the number of days in the specified Shamsi year.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// int days = calendarOps.GetDaysInYear(1403); // Returns 366 for a leap year
    /// int days2 = calendarOps.GetDaysInYear(1402); // Returns 365 for a normal year
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <returns>The number of days in the specified year (365 or 366).</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the year is outside the supported range.</exception>
    public int GetDaysInYear(int shamsiYear)
    {
        try
        {
            return persianCalendar.GetDaysInYear(shamsiYear);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException(nameof(shamsiYear), $"The year {shamsiYear} is outside the supported range for Persian calendar.");
        }
    }

    /// <summary>
    /// Gets the Gregorian date for Nowruz (Persian New Year) of the specified Shamsi year.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// DateTime nowruz = calendarOps.GetNewYearDate(1404); // Returns the Gregorian date for 1 Farvardin 1404
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <returns>The Gregorian DateTime representing the first day of the specified Shamsi year.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the year is outside the supported range.</exception>
    public DateTime GetNewYearDate(int shamsiYear)
    {
        try
        {
            return persianCalendar.ToDateTime(shamsiYear, 1, 1, 0, 0, 0, 0);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException(nameof(shamsiYear), $"The year {shamsiYear} is outside the supported range for Persian calendar.");
        }
    }

    /// <summary>
    /// Gets the first day of the specified Shamsi month.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// DateTime firstDay = calendarOps.GetFirstDayOfMonth(1403, 7); // Returns 1 Mehr 1403
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <param name="shamsiMonth">The Shamsi month (1-12).</param>
    /// <returns>The Gregorian DateTime representing the first day of the specified Shamsi month.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the year or month is outside the valid range.</exception>
    public DateTime GetFirstDayOfMonth(int shamsiYear, int shamsiMonth)
    {
        if (shamsiMonth < 1 || shamsiMonth > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(shamsiMonth), "Month must be between 1 and 12.");
        }

        try
        {
            return persianCalendar.ToDateTime(shamsiYear, shamsiMonth, 1, 0, 0, 0, 0);
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new ArgumentOutOfRangeException(nameof(shamsiYear), $"The year {shamsiYear} is outside the supported range for Persian calendar.");
        }
    }

    /// <summary>
    /// Gets the last day of the specified Shamsi month.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// DateTime lastDay = calendarOps.GetLastDayOfMonth(1403, 12); // Returns 30 Esfand 1403 (leap year)
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <param name="shamsiMonth">The Shamsi month (1-12).</param>
    /// <returns>The Gregorian DateTime representing the last day of the specified Shamsi month.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the year or month is outside the valid range.</exception>
    public DateTime GetLastDayOfMonth(int shamsiYear, int shamsiMonth)
    {
        int daysInMonth = GetDaysInMonth(shamsiYear, shamsiMonth);
        return persianCalendar.ToDateTime(shamsiYear, shamsiMonth, daysInMonth, 23, 59, 59, 999);
    }

    /// <summary>
    /// Gets all dates within a specified Shamsi date range.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// var dates = calendarOps.GetDateRange(1403, 1, 1, 1403, 1, 10);
    /// // Returns all dates from 1 to 10 Farvardin 1403
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="startYear">The start Shamsi year.</param>
    /// <param name="startMonth">The start Shamsi month.</param>
    /// <param name="startDay">The start Shamsi day.</param>
    /// <param name="endYear">The end Shamsi year.</param>
    /// <param name="endMonth">The end Shamsi month.</param>
    /// <param name="endDay">The end Shamsi day.</param>
    /// <returns>A list of DateTime objects representing all dates in the range.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when any date component is outside the valid range.</exception>
    /// <exception cref="ArgumentException">Thrown when the start date is after the end date.</exception>
    public List<DateTime> GetDateRange(int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
    {
        DateTime startDate;
        DateTime endDate;

        try
        {
            startDate = persianCalendar.ToDateTime(startYear, startMonth, startDay, 0, 0, 0, 0);
            endDate = persianCalendar.ToDateTime(endYear, endMonth, endDay, 0, 0, 0, 0);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            throw new ArgumentOutOfRangeException("Invalid date parameters", ex);
        }

        if (startDate > endDate)
        {
            throw new ArgumentException("Start date cannot be after end date.");
        }

        List<DateTime> dates = [];
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            dates.Add(date);
        }

        return dates;
    }

    /// <summary>
    /// Gets all dates in the specified Shamsi month.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// var dates = calendarOps.GetDatesInMonth(1403, 1); // Returns all 31 dates in Farvardin 1403
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <param name="shamsiMonth">The Shamsi month (1-12).</param>
    /// <returns>A list of DateTime objects representing all dates in the month.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the year or month is outside the valid range.</exception>
    public List<DateTime> GetDatesInMonth(int shamsiYear, int shamsiMonth)
    {
        int daysInMonth = GetDaysInMonth(shamsiYear, shamsiMonth);
        return GetDateRange(shamsiYear, shamsiMonth, 1, shamsiYear, shamsiMonth, daysInMonth);
    }

    /// <summary>
    /// Gets all dates in the specified Shamsi year.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// var dates = calendarOps.GetDatesInYear(1403); // Returns all 366 dates in 1403 (leap year)
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <returns>A list of DateTime objects representing all dates in the year.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the year is outside the supported range.</exception>
    public List<DateTime> GetDatesInYear(int shamsiYear)
    {
        return GetDateRange(shamsiYear, 1, 1, shamsiYear, 12, GetDaysInMonth(shamsiYear, 12));
    }

    /// <summary>
    /// Adds the specified number of Shamsi months to a date.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// DateTime newDate = calendarOps.AddShamsiMonths(DateTime.Now, 3); // Adds 3 Shamsi months
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The base date.</param>
    /// <param name="months">The number of months to add (can be negative).</param>
    /// <returns>A new DateTime with the months added.</returns>
    public DateTime AddShamsiMonths(DateTime date, int months)
    {
        int shamsiYear = persianCalendar.GetYear(date);
        int shamsiMonth = persianCalendar.GetMonth(date);
        int shamsiDay = persianCalendar.GetDayOfMonth(date);

        shamsiMonth += months;

        // Handle month overflow/underflow
        while (shamsiMonth > 12)
        {
            shamsiMonth -= 12;
            shamsiYear++;
        }
        while (shamsiMonth < 1)
        {
            shamsiMonth += 12;
            shamsiYear--;
        }

        // Adjust day if the target month has fewer days
        int daysInTargetMonth = GetDaysInMonth(shamsiYear, shamsiMonth);
        if (shamsiDay > daysInTargetMonth)
        {
            shamsiDay = daysInTargetMonth;
        }

        return persianCalendar.ToDateTime(shamsiYear, shamsiMonth, shamsiDay,
            date.Hour, date.Minute, date.Second, date.Millisecond);
    }

    /// <summary>
    /// Adds the specified number of Shamsi years to a date.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// DateTime newDate = calendarOps.AddShamsiYears(DateTime.Now, 5); // Adds 5 Shamsi years
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The base date.</param>
    /// <param name="years">The number of years to add (can be negative).</param>
    /// <returns>A new DateTime with the years added.</returns>
    public DateTime AddShamsiYears(DateTime date, int years)
    {
        int shamsiYear = persianCalendar.GetYear(date);
        int shamsiMonth = persianCalendar.GetMonth(date);
        int shamsiDay = persianCalendar.GetDayOfMonth(date);

        shamsiYear += years;

        // Handle leap year adjustments for Esfand 30
        if (shamsiMonth == 12 && shamsiDay == 30 && !IsLeapYear(shamsiYear))
        {
            shamsiDay = 29; // Adjust to last day of Esfand in non-leap year
        }

        return persianCalendar.ToDateTime(shamsiYear, shamsiMonth, shamsiDay,
            date.Hour, date.Minute, date.Second, date.Millisecond);
    }

    /// <summary>
    /// Gets the number of days between two dates in the Shamsi calendar.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// int days = calendarOps.GetDaysBetween(date1, date2); // Returns difference in days
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns>The number of days between the two dates (positive if endDate is after startDate).</returns>
    public int GetDaysBetween(DateTime startDate, DateTime endDate)
    {
        return (int)(endDate.Date - startDate.Date).TotalDays;
    }

    /// <summary>
    /// Gets the Shamsi season for the specified date.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// string season = calendarOps.GetSeason(DateTime.Now); // Returns "بهار", "تابستان", "پاییز", or "زمستان"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>The Persian name of the season.</returns>
    public string GetSeason(DateTime date)
    {
        int shamsiMonth = persianCalendar.GetMonth(date);

        return shamsiMonth switch
        {
            1 or 2 or 3 => "بهار", // Spring: Farvardin, Ordibehesht, Khordad
            4 or 5 or 6 => "تابستان", // Summer: Tir, Mordad, Shahrivar
            7 or 8 or 9 => "پاییز", // Autumn: Mehr, Aban, Azar
            10 or 11 or 12 => "زمستان", // Winter: Dey, Bahman, Esfand
            _ => throw new ArgumentOutOfRangeException(nameof(date), "Invalid month detected.")
        };
    }

    /// <summary>
    /// Gets the week number of the specified date within its Shamsi year.
    /// <example>
    /// <code>
    /// var calendarOps = new ShamsiCalendarOperations();
    /// int week = calendarOps.GetWeekOfYear(DateTime.Now); // Returns week number (1-53)
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>The week number within the Shamsi year (1-based).</returns>
    public int GetWeekOfYear(DateTime date)
    {
        int shamsiYear = persianCalendar.GetYear(date);
        DateTime newYearDate = GetNewYearDate(shamsiYear);

        // Calculate days from start of year
        int dayOfYear = (int)(date.Date - newYearDate.Date).TotalDays + 1;

        // Find the day of week for New Year (Saturday = 0, Sunday = 1, ... Friday = 6)
        int newYearDayOfWeek = ((int)newYearDate.DayOfWeek + 1) % 7;

        // Adjust for Persian week (Saturday is first day)
        int adjustedDayOfYear = dayOfYear + newYearDayOfWeek - 1;

        return (adjustedDayOfYear - 1) / 7 + 1;
    }
}
