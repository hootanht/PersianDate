using System;
using System.Globalization;

namespace PersianDate
{
    public class PersianDateShamsi
    {
        PersianCalendar persianCalendar;
        public PersianDateShamsi()
        {
            persianCalendar = new PersianCalendar();
        }
        /// <returns></returns>
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
        /// Get Short Shamsi Year From Miladi Year In String
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string? GetShortShamsiYear(DateTime? dateTime)
        {
            return dateTime?.ToString("yy", CultureInfo.CreateSpecificCulture("fa"));
        }
        /// <summary>
        /// Get Shamsi Year From Miladi Year In String
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
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
        /// Get Shamsi Month From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        public int? GetShamsiMonth(DateTime? dateTime)
        {
            return dateTime.HasValue ? persianCalendar.GetMonth(dateTime.Value) : null;
        }
        /// <summary>
        /// Get Shamsi Month Number From Miladi Month In String
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string GetShamsiMonthString(DateTime dateTime)
        {
            return persianCalendar.GetMonth(dateTime).ToString("00");
        }
        /// <summary>
        /// Get Shamsi Month From Miladi Month Number
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public int? GetShamsiMonthNumber(DateTime? dateTime)
        {
            return dateTime.HasValue ? persianCalendar.GetMonth(dateTime.Value) : null;
        }
        /// <summary>
        /// Get Shamsi Month Name From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string? GetShamsiMonthName(DateTime? dateTime)
        {
            return dateTime?.ToString("MMMM", CultureInfo.CreateSpecificCulture("fa"));
        }


        /// <summary>
        /// Get Shamsi Day From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public int? GetShamsiDay(DateTime? dateTime)
        {
            return dateTime.HasValue ? persianCalendar.GetDayOfMonth(dateTime.Value) : null;
        }
        /// <summary>
        /// Get Shamsi Day From Miladi Month In String
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string? GetShamsiDayString(DateTime? dateTime)
        {
            return dateTime.HasValue ? persianCalendar.GetDayOfMonth(dateTime.Value).ToString("00") : null;
        }
        /// <summary>
        /// Get Shamsi Day Name From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string? GetShamsiDayName(DateTime? dateTime)
        {
            return dateTime?.ToString("dddd", CultureInfo.CreateSpecificCulture("fa"));
        }
        /// <summary>
        /// Get Shamsi Day ShortName From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string? GetShamsiDayShortName(DateTime? dateTime)
        {
            return (dateTime?.ToString("dddd", CultureInfo.CreateSpecificCulture("fa")))?[..1];
        }
    }
}
