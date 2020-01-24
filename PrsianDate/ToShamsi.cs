using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianDate
{
    public static class ToShamsi
    {
        /// <summary>
        /// Get Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async static Task<string> ToShamsiDateAsync(this DateTime dateTime)
        {
            PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
            return await persianDateShamsi.GetShamsiYearToStringAsync(dateTime) + "/" + await persianDateShamsi.GetShamsiMonthStringAsync(dateTime) + "/" + await persianDateShamsi.GetShamsiDayStringAsync(dateTime);
        }
        /// <summary>
        /// Get Short Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async static Task<string> ToShortShamsiDateAsync(this DateTime dateTime)
        {
            PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
            return await persianDateShamsi.GetShortShamsiYearAsync(dateTime) + "/" + await persianDateShamsi.GetShamsiMonthStringAsync(dateTime) + "/" + await persianDateShamsi.GetShamsiDayStringAsync(dateTime);
        }
        /// <summary>
        /// Get Long Shamsi Date From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async static Task<string> ToLongShamsiDateAsync(this DateTime dateTime)
        {
            PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
            return await persianDateShamsi.GetShamsiDayNameAsync(dateTime) + " " + await persianDateShamsi.GetShamsiDayAsync(dateTime) + " " + await persianDateShamsi.GetShamsiMonthNameAsync(dateTime) + " " + await persianDateShamsi.GetShamsiYearAsync(dateTime);
        }
    }
}
