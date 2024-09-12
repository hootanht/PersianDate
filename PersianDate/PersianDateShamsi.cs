using System;
using System.Globalization;

namespace PersianDate
{
    /// <summary>
    /// Provides methods to convert Gregorian dates to Persian (Shamsi) dates.
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
        /// </summary>
        /// <param name="dateTime">The Gregorian date.</param>
        /// <returns>The Shamsi year, or null if the input is null or out of range.</returns>
        public int? GetShamsiYear(DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return null;

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
        /// Gets the short Shamsi year from the specified Gregorian date as a string.
        /// </summary>
        /// <param name="dateTime">The Gregorian date.</param>
        /// <returns>The short Shamsi year as a string, or null if the input is null.</returns>
        public string? GetShortShamsiYear(DateTime? dateTime)
        {
            return dateTime?.ToString("yy", CultureInfo.CreateSpecificCulture("fa"));
        }

        /// <summary>
        /// Gets the Shamsi year from the specified Gregorian date as a string.
        /// </summary>
        /// <param name="dateTime">The Gregorian date.</param>
        /// <returns>The Shamsi year as a string, or null if the input is null or out of range.</returns>
        public string? GetShamsiYearToString(DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return null;

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
        /// Gets the Shamsi month from the specified Gregorian date.
        /// </summary>
        /// <param name="dateTime">The Gregorian date.</param>
        /// <returns>The Shamsi month, or null if the input is null.</returns>
        public int? GetShamsiMonth(DateTime? dateTime)
        {
            return dateTime.HasValue ? persianCalendar.GetMonth(dateTime.Value) : null;
        }

        /// <summary>
        /// Gets the Shamsi month number from the specified Gregorian date as a string.
        /// </summary>
        /// <param name="dateTime">The Gregorian date.</param>
        /// <returns>The Shamsi month number as a string.</returns>
        public string GetShamsiMonthString(DateTime dateTime)
        {
            return persianCalendar.GetMonth(dateTime).ToString("00");
        }

        /// <summary>
        /// Gets the Shamsi month number from the specified Gregorian date.
        /// </summary>
        /// <param name="dateTime">The Gregorian date.</param>
        /// <returns>The Shamsi month number, or null if the input is null.</returns>
        public int? GetShamsiMonthNumber(DateTime? dateTime)
        {
            return dateTime.HasValue ? persianCalendar.GetMonth(dateTime.Value) : null;
        }

        /// <summary>
        /// Gets the Shamsi month name from the specified Gregorian date.
        /// </summary>
        /// <param name="dateTime">The Gregorian date.</param>
        /// <returns>The Shamsi month name, or null if the input is null.</returns>
        public string? GetShamsiMonthName(DateTime? dateTime)
        {
            return dateTime?.ToString("MMMM", CultureInfo.CreateSpecificCulture("fa"));
        }

        /// <summary>
        /// Gets the Shamsi day from the specified Gregorian date.
        /// </summary>
        /// <param name="dateTime">The Gregorian date.</param>
        /// <returns>The Shamsi day, or null if the input is null.</returns>
        public int? GetShamsiDay(DateTime? dateTime)
        {
            return dateTime.HasValue ? persianCalendar.GetDayOfMonth(dateTime.Value) : null;
        }

        /// <summary>
        /// Gets the Shamsi day from the specified Gregorian date as a string.
        /// </summary>
        /// <param name="dateTime">The Gregorian date.</param>
        /// <returns>The Shamsi day as a string, or null if the input is null.</returns>
        public string? GetShamsiDayString(DateTime? dateTime)
        {
            return dateTime.HasValue ? persianCalendar.GetDayOfMonth(dateTime.Value).ToString("00") : null;
        }

        /// <summary>
        /// Gets the Shamsi day name from the specified Gregorian date.
        /// </summary>
        /// <param name="dateTime">The Gregorian date.</param>
        /// <returns>The Shamsi day name, or null if the input is null.</returns>
        public string? GetShamsiDayName(DateTime? dateTime)
        {
            return dateTime?.ToString("dddd", CultureInfo.CreateSpecificCulture("fa"));
        }

        /// <summary>
        /// Gets the short Shamsi day name from the specified Gregorian date.
        /// </summary>
        /// <param name="dateTime">The Gregorian date.</param>
        /// <returns>The short Shamsi day name, or null if the input is null.</returns>
        public string? GetShamsiDayShortName(DateTime? dateTime)
        {
            return (dateTime?.ToString("dddd", CultureInfo.CreateSpecificCulture("fa")))?[..1];
        }
    }
}
