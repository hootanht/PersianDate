using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersianDate
{
    public static class ToShamsi
    {
        public async static Task<string> ToShamsiDate(this DateTime dateTime)
        {
            PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
            return await persianDateShamsi.GetShamsiYearToStringAsync(dateTime) + "/" + await persianDateShamsi.GetShamsiMonthStringAsync(dateTime) + "/" + await persianDateShamsi.GetShamsiDayStringAsync(dateTime);
        }
        public async static Task<string> ToShortShamsiDate(this DateTime dateTime)
        {
            PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
            return await persianDateShamsi.GetShortShamsiYearAsync(dateTime) + "/" + await persianDateShamsi.GetShamsiMonthStringAsync(dateTime) + "/" + await persianDateShamsi.GetShamsiDayStringAsync(dateTime);
        }
        public async static Task<string> ToLongShamsiDate(this DateTime dateTime)
        {
            PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
            return await persianDateShamsi.GetShamsiDayNameAsync(dateTime) + " " + await persianDateShamsi.GetShamsiDayAsync(dateTime) + " " + await persianDateShamsi.GetShamsiMonthNameAsync(dateTime) + " " + await persianDateShamsi.GetShamsiYearAsync(dateTime);
        }
    }
}
