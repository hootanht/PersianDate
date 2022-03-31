﻿using System;
using System.Globalization;

namespace PersianDate
{
    public class PersianDateShamsi
    {
        PersianCalendar persianCalendar;
        string[] DaysOfWeek;

        public PersianDateShamsi()
        {
            persianCalendar = new PersianCalendar();
            DaysOfWeek = new string[] { "شنبه", "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" };
        }

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
            return dateTime.ToString("yy", CultureInfo.CreateSpecificCulture("fa"));
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
            return dateTime.ToString("MMMM", CultureInfo.CreateSpecificCulture("fa"));
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
            return DaysOfWeek[(int)persianCalendar.GetDayOfWeek(dateTime)];
        }
        /// <summary>
        /// Get Shamsi Day ShortName From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public string GetShamsiDayShortName(DateTime dateTime)
        {
            return DaysOfWeek[(int)persianCalendar.GetDayOfWeek(dateTime)].Substring(0, 1);
        }
        #endregion
    }
}
