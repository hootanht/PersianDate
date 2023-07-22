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
        public static string? ToShamsiDate(this DateTime? dateTime)
        {
            if (dateTime == null) 
                return null;

            var persianDateShamsi = new PersianDateShamsi();
            return persianDateShamsi.GetShamsiYearToString(dateTime.Value) + "/" + persianDateShamsi.GetShamsiMonthString(dateTime.Value) + "/" + persianDateShamsi.GetShamsiDayString(dateTime.Value);
        }
        /// <summary>
        /// Get Short Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public static string? ToShortShamsiDate(this DateTime? dateTime)
        {
            if (dateTime == null)
                return null;

            var persianDateShamsi = new PersianDateShamsi();
            return persianDateShamsi.GetShortShamsiYear(dateTime.Value) + "/" + persianDateShamsi.GetShamsiMonthString(dateTime.Value) + "/" + persianDateShamsi.GetShamsiDayString(dateTime.Value);
        }
        /// <summary>
        /// Get Long Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public static string? ToLongShamsiDate(this DateTime? dateTime)
        {
            if (dateTime == null)
                return null;

            var persianDateShamsi = new PersianDateShamsi();
            return persianDateShamsi.GetShamsiDayName(dateTime.Value) + " " + persianDateShamsi.GetShamsiDay(dateTime.Value) + " " + persianDateShamsi.GetShamsiMonthName(dateTime.Value) + " " + persianDateShamsi.GetShamsiYear(dateTime.Value);
        }
    }
}
