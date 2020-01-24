using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersianDate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace PersianDateTests
{
    [TestClass]
    public class DateTest
    {
        //My Birthday
        DateTime dateTime = new DateTime(1998, 1, 11);
        PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
        [TestMethod]
        public async Task YearAsyncTest()
        {
            Assert.AreEqual(1376,await persianDateShamsi.GetShamsiYearAsync(dateTime));
        }
        [TestMethod]
        public async Task ShortYearAsyncTest()
        {
            Assert.AreEqual("76",await persianDateShamsi.GetShortShamsiYearAsync(dateTime));
        }
        [TestMethod]
        public async Task YearStringAsyncTest()
        {
            Assert.AreEqual("1376",await persianDateShamsi.GetShamsiYearToStringAsync(dateTime));
        }
        [TestMethod]
        public async Task MonthAsyncTest()
        {
            Assert.AreEqual(10,await persianDateShamsi.GetShamsiMonthAsync(dateTime));
        }
        [TestMethod]
        public async Task MonthStringAsyncTest()
        {
            Assert.AreEqual("10",await persianDateShamsi.GetShamsiMonthStringAsync(dateTime));
        }
        [TestMethod]
        public async Task MonthNameAsyncTest()
        {
            Assert.AreEqual("دی",await persianDateShamsi.GetShamsiMonthNameAsync(dateTime));
        }
        [TestMethod]
        public async Task DayAsyncTest()
        {
            Assert.AreEqual(21,await persianDateShamsi.GetShamsiDayAsync(dateTime));
        }
        [TestMethod]
        public async Task DayStringAsyncTest()
        {
            Assert.AreEqual("21",await persianDateShamsi.GetShamsiDayStringAsync(dateTime));
        }
        [TestMethod]
        public async Task DayNameAsyncTest()
        {
            Assert.AreEqual("يكشنبه", await persianDateShamsi.GetShamsiDayNameAsync(dateTime));
        }
        [TestMethod]
        public async Task DayShortNameAsyncTest()
        {
            Assert.AreEqual("ي", await persianDateShamsi.GetShamsiDayShortNameAsync(dateTime));
        }
    }
}
