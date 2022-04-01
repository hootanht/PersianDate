using System;
using System.Globalization;

namespace PersianDate
{
    public class PersianDateShamsi
    {
        #region Constants

        PersianCalendar persianCalendar;
        string[] DaysOfWeek;
        string[] DaysOfWeekShort;
        string[] Months;

        public PersianDateShamsi()
        {
            persianCalendar = new PersianCalendar();
            DaysOfWeek = new string[] { "شنبه", "يكشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };
            DaysOfWeekShort = new string[] { "ش", "ي", "د", "س", "چ", "پ", "ج" };
            Months = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        }

        #endregion

        #region Year
        /// <summary>
        /// Get Shamsi Year From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public int GetShamsiYear(DateTime dateTime)
        {
            return persianCalendar.GetYear(dateTime);
        }
        /// <summary>
        /// Get Short Shamsi Year From Miladi Year In String
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string GetShortShamsiYear(DateTime dateTime)
        {
            var pc = new PersianCalendar();
            return pc.GetYear(dateTime).ToString().Substring(2, 2);
        }
        /// <summary>
        /// Get Shamsi Year From Miladi Year In String
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string GetShamsiYearToString(DateTime dateTime)
        {
            return persianCalendar.GetYear(dateTime).ToString();
        }
        #endregion

        #region Month
        /// <summary>
        /// Get Shamsi Month From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public int GetShamsiMonth(DateTime dateTime)
        {
            return persianCalendar.GetMonth(dateTime);
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
        public int GetShamsiMonthBunber(DateTime dateTime)
        {
            return persianCalendar.GetMonth(dateTime);
        }
        /// <summary>
        /// Get Shamsi Month Name From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string GetShamsiMonthName(DateTime dateTime)
        {
            return Months[(persianCalendar.GetMonth(dateTime) - 1)];
        }
        #endregion

        #region Day
        /// <summary>
        /// Get Shamsi Day From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public int GetShamsiDay(DateTime dateTime)
        {
            return persianCalendar.GetDayOfMonth(dateTime);
        }
        /// <summary>
        /// Get Shamsi Day From Miladi Month In String
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string GetShamsiDayString(DateTime dateTime)
        {
            return persianCalendar.GetDayOfMonth(dateTime).ToString("00");
        }
        /// <summary>
        /// Get Shamsi Day Name From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string GetShamsiDayName(DateTime dateTime)
        {
            return DaysOfWeek[(int)persianCalendar.GetDayOfWeek(dateTime) + 1];
        }
        /// <summary>
        /// Get Shamsi Day ShortName From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string GetShamsiDayShortName(DateTime dateTime)
        {
            return DaysOfWeekShort[(int)persianCalendar.GetDayOfWeek(dateTime) + 1];
        }
        #endregion
    }
}
