using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace PersianDate
{
    public class PersianDateShamsi
    {
        PersianCalendar persianCalendar;
        public PersianDateShamsi()
        {
            persianCalendar = new PersianCalendar();
        }
        #region Year
        /// <summary>
        /// Get Shamsi Year From Miladi Year
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async Task<int> GetShamsiYearAsync(DateTime dateTime)
        {
            int date = 0;
            await Task.Run(() =>
            {
                date = persianCalendar.GetYear(dateTime);
            });
            return date;
        }
        /// <summary>
        /// Get Short Shamsi Year From Miladi Year In String
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async Task<string> GetShortShamsiYearAsync(DateTime dateTime)
        {
            string date = "";
            await Task.Run(() =>
            {
                date = dateTime.ToString("yy", CultureInfo.CreateSpecificCulture("fa"));
            });
            return date;
        }
        /// <summary>
        /// Get Shamsi Year From Miladi Year In String
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async Task<string> GetShamsiYearToStringAsync(DateTime dateTime)
        {
            int date = 0;
            await Task.Run(() =>
            {
                date = persianCalendar.GetYear(dateTime);
            });
            return date.ToString();
        }
        #endregion

        #region Month
        /// <summary>
        /// Get Shamsi Month From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async Task<int> GetShamsiMonthAsync(DateTime dateTime)
        {
            int date = 0;
            await Task.Run(() =>
            {
                date = persianCalendar.GetMonth(dateTime);
            });
            return date;
        }
        /// <summary>
        /// Get Shamsi Month Number From Miladi Month In String
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async Task<string> GetShamsiMonthStringAsync(DateTime dateTime)
        {
            int date = 0;
            await Task.Run(() =>
            {
                date = persianCalendar.GetMonth(dateTime);
            });
            return date.ToString("00");
        }
        /// <summary>
        /// Get Shamsi Month From Miladi Month Number
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async Task<int> GetShamsiMonthBunberAsync(DateTime dateTime)
        {
            int date = 0;
            await Task.Run(() =>
            {
                date = persianCalendar.GetMonth(dateTime);
            });
            return date;
        }
        /// <summary>
        /// Get Shamsi Month Name From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async Task<string> GetShamsiMonthNameAsync(DateTime dateTime)
        {
            string fullMonthName = "";
            await Task.Run(() =>
            {
               fullMonthName = dateTime.ToString("MMMM", CultureInfo.CreateSpecificCulture("fa"));
            });
            return fullMonthName;
        }
        #endregion

        #region Day
        /// <summary>
        /// Get Shamsi Day From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async Task<int> GetShamsiDayAsync(DateTime dateTime)
        {
            int date = 0;
            await Task.Run(() =>
            {
                date = persianCalendar.GetDayOfMonth(dateTime);
            });
            return date;
        }
        /// <summary>
        /// Get Shamsi Day From Miladi Month In String
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async Task<string> GetShamsiDayStringAsync(DateTime dateTime)
        {
            int date = 0;
            await Task.Run(() =>
            {
                date = persianCalendar.GetDayOfMonth(dateTime);
            });
            return date.ToString("00");
        }
        /// <summary>
        /// Get Shamsi Day Name From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async Task<string> GetShamsiDayNameAsync(DateTime dateTime)
        {
            string fullDayName = "";
            await Task.Run(() =>
            {
                fullDayName = dateTime.ToString("dddd", CultureInfo.CreateSpecificCulture("fa"));
            });
            return fullDayName;
        }
        /// <summary>
        /// Get Shamsi Day ShortName From Miladi Month
        /// </summary>
        /// <param name="dateTime">Enter The Jalali DateTime</param>
        /// <returns></returns>
        public async Task<string> GetShamsiDayShortNameAsync(DateTime dateTime)
        {
            string fullDayName = "";
            await Task.Run(() =>
            {
                fullDayName = dateTime.ToString("dddd", CultureInfo.CreateSpecificCulture("fa"));
            });
            return fullDayName.Substring(0, 1);
        }
        #endregion
    }
}
