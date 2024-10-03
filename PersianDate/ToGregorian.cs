using System;
using System.Collections.Generic;
using System.Globalization;
using PersianDate.Utills;

namespace PersianDate;
/// <summary>
/// Provides methods to convert Persian (Shamsi) dates to Gregorian dates.
/// <example>
/// <code>
/// var persianDate = new ToGregorian();
/// var gregorianYear = persianDate.GetGregorianYear(1402, 1, 1); // 2023
/// var gregorianDate = persianDate.ToGregorianDate(1402, 1, 1); // 2023-03-21
/// </code>
/// </example>
/// </summary>
public class ToGregorian
{
    private readonly PersianCalendar persianCalendar;

    /// <summary>
    /// Initializes a new instance of the <see cref="ToGregorian"/> class.
    /// </summary>
    public ToGregorian()
    {
        persianCalendar = new PersianCalendar();
    }

    /// <summary>
    /// Gets the Gregorian year from the specified Shamsi date.
    /// <example>
    /// <code>
    /// var persianDate = new ToGregorian();
    /// int gregorianYear = persianDate.GetGregorianYear(1402, 1, 1); // Returns 2023
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <param name="shamsiMonth">The Shamsi month.</param>
    /// <param name="shamsiDay">The Shamsi day.</param>
    /// <returns>The Gregorian year.</returns>
    public int GetGregorianYear(int shamsiYear, int shamsiMonth, int shamsiDay)
    {
        DateTime gregorianDate = persianCalendar.ToDateTime(shamsiYear, shamsiMonth, shamsiDay, 0, 0, 0, 0);
        return gregorianDate.Year;
    }

    /// <summary>
    /// Converts the specified Shamsi date to a Gregorian date.
    /// <example>
    /// <code>
    /// var persianDate = new ToGregorian();
    /// DateTime gregorianDate = persianDate.ToGregorianDate(1402, 1, 1); // Returns 2023-03-21
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <param name="shamsiMonth">The Shamsi month.</param>
    /// <param name="shamsiDay">The Shamsi day.</param>
    /// <returns>The Gregorian date.</returns>
    public DateTime ToGregorianDate(int shamsiYear, int shamsiMonth, int shamsiDay)
    {
        return persianCalendar.ToDateTime(shamsiYear, shamsiMonth, shamsiDay, 0, 0, 0, 0);
    }

    /// <summary>
    /// Gets the Gregorian month from the specified Shamsi date.
    /// <example>
    /// <code>
    /// var persianDate = new ToGregorian();
    /// int gregorianMonth = persianDate.GetGregorianMonth(1402, 1, 1); // Returns 3
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <param name="shamsiMonth">The Shamsi month.</param>
    /// <param name="shamsiDay">The Shamsi day.</param>
    /// <returns>The Gregorian month.</returns>
    public int GetGregorianMonth(int shamsiYear, int shamsiMonth, int shamsiDay)
    {
        DateTime gregorianDate = persianCalendar.ToDateTime(shamsiYear, shamsiMonth, shamsiDay, 0, 0, 0, 0);
        return gregorianDate.Month;
    }

    /// <summary>
    /// Gets the Gregorian day from the specified Shamsi date.
    /// <example>
    /// <code>
    /// var persianDate = new ToGregorian();
    /// int gregorianDay = persianDate.GetGregorianDay(1402, 1, 1); // Returns 21
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <param name="shamsiMonth">The Shamsi month.</param>
    /// <param name="shamsiDay">The Shamsi day.</param>
    /// <returns>The Gregorian day.</returns>
    public int GetGregorianDay(int shamsiYear, int shamsiMonth, int shamsiDay)
    {
        DateTime gregorianDate = persianCalendar.ToDateTime(shamsiYear, shamsiMonth, shamsiDay, 0, 0, 0, 0);
        return gregorianDate.Day;
    }

    /// <summary>
    /// Gets the Gregorian date as a string from the specified Shamsi date.
    /// <example>
    /// <code>
    /// var persianDate = new ToGregorian();
    /// string gregorianDateString = persianDate.GetGregorianDateString(1402, 1, 1); // Returns "2023-03-21"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <param name="shamsiMonth">The Shamsi month.</param>
    /// <param name="shamsiDay">The Shamsi day.</param>
    /// <returns>The Gregorian date as a string.</returns>
    public string GetGregorianDateString(int shamsiYear, int shamsiMonth, int shamsiDay)
    {
        DateTime gregorianDate = persianCalendar.ToDateTime(shamsiYear, shamsiMonth, shamsiDay, 0, 0, 0, 0);
        return gregorianDate.ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// Gets the Gregorian day name from the specified Shamsi date.
    /// <example>
    /// <code>
    /// var persianDate = new ToGregorian();
    /// string gregorianDayName = persianDate.GetGregorianDayName(1402, 1, 1); // Returns "Tuesday"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <param name="shamsiMonth">The Shamsi month.</param>
    /// <param name="shamsiDay">The Shamsi day.</param>
    /// <returns>The Gregorian day name.</returns>
    public string GetGregorianDayName(int shamsiYear, int shamsiMonth, int shamsiDay)
    {
        DateTime gregorianDate = persianCalendar.ToDateTime(shamsiYear, shamsiMonth, shamsiDay, 0, 0, 0, 0);
        return gregorianDate.ToString("dddd", CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Gets the Gregorian day name based on a specific Persian character.
    /// <example>
    /// <code>
    /// var persianDate = new ToGregorian();
    /// string dayName = persianDate.GetDayNameFromPersianCharacter('ی'); // Returns "Sunday"
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="persianCharacter">The Persian character.</param>
    /// <returns>The corresponding Gregorian day name.</returns>
    public string GetDayNameFromPersianCharacter(char persianCharacter)
    {
        char convertedCharacter = StringUtil.ConvertToPersianCharacter(persianCharacter);
        return convertedCharacter switch
        {
            'ی' => "Sunday",
            'د' => "Monday",
            'س' => "Tuesday",
            'چ' => "Wednesday",
            'پ' => "Thursday",
            'ج' => "Friday",
            'ش' => "Saturday",
            _ => "Unknown"
        };
    }

    /// <summary>
    /// Converts a range of Shamsi dates to Gregorian dates.
    /// <example>
    /// <code>
    /// var persianDate = new ToGregorian();
    /// var gregorianDates = persianDate.ConvertRangeToGregorian(1402, 1, 1, 1402, 1, 10);
    /// // Returns a list of Gregorian dates from 2023-03-21 to 2023-03-30
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="startYear">The start Shamsi year.</param>
    /// <param name="startMonth">The start Shamsi month.</param>
    /// <param name="startDay">The start Shamsi day.</param>
    /// <param name="endYear">The end Shamsi year.</param>
    /// <param name="endMonth">The end Shamsi month.</param>
    /// <param name="endDay">The end Shamsi day.</param>
    /// <returns>A list of Gregorian dates.</returns>
    public List<DateTime> ConvertRangeToGregorian(int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
    {
        List<DateTime> gregorianDates = [];
        DateTime startDate = persianCalendar.ToDateTime(startYear, startMonth, startDay, 0, 0, 0, 0);
        DateTime endDate = persianCalendar.ToDateTime(endYear, endMonth, endDay, 0, 0, 0, 0);

        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            gregorianDates.Add(date);
        }

        return gregorianDates;
    }

    /// <summary>
    /// Gets the Gregorian date for the first day of the specified Shamsi month.
    /// <example>
    /// <code>
    /// var persianDate = new ToGregorian();
    /// DateTime firstDay = persianDate.GetFirstDayOfShamsiMonth(1402, 1);
    /// // Returns 2023-03-21
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="shamsiYear">The Shamsi year.</param>
    /// <param name="shamsiMonth">The Shamsi month.</param>
    /// <returns>The Gregorian date for the first day of the specified Shamsi month.</returns>
    public DateTime GetFirstDayOfShamsiMonth(int shamsiYear, int shamsiMonth)
    {
        return persianCalendar.ToDateTime(shamsiYear, shamsiMonth, 1, 0, 0, 0, 0);
    }
}
