using System;

namespace PersianDate
{
    public static class ToShamsi
    {
        /// <summary>
        /// Get Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns>A string representing the Shamsi date or null if the input is null.</returns>
        public static string? ToShamsiDate(this DateTime dateTime)
        {
            var persianDateShamsi = new PersianDateShamsi();
            return persianDateShamsi.GetShamsiYearToString(dateTime) + "/" + persianDateShamsi.GetShamsiMonthString(dateTime) + "/" + persianDateShamsi.GetShamsiDayString(dateTime);
        }
        /// <summary>
        /// Get Short Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public static string? ToShortShamsiDate(this DateTime dateTime)
        {
            var persianDateShamsi = new PersianDateShamsi();
            return persianDateShamsi.GetShortShamsiYear(dateTime) + "/" + persianDateShamsi.GetShamsiMonthString(dateTime) + "/" + persianDateShamsi.GetShamsiDayString(dateTime);
        }
        /// <summary>
        /// Get Long Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public static string? ToLongShamsiDate(this DateTime dateTime)
        {
            var persianDateShamsi = new PersianDateShamsi();
            return persianDateShamsi.GetShamsiDayName(dateTime) + " " + persianDateShamsi.GetShamsiDay(dateTime) + " " + persianDateShamsi.GetShamsiMonthName(dateTime) + " " + persianDateShamsi.GetShamsiYear(dateTime);
        }
    }
}
