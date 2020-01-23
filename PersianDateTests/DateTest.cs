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
        PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
        [TestMethod]
        public async Task YearTest()
        {
            Assert.AreEqual(1398, await persianDateShamsi.GetShamsiYearAsync(DateTime.Now));
        }
        [TestMethod]
        public async Task ShortYearTest()
        {
            Assert.AreEqual("98", await persianDateShamsi.GetShortShamsiYearAsync(DateTime.Now));
        }
        [TestMethod]
        public async Task YearStringTest()
        {
            Assert.AreEqual("1398", await persianDateShamsi.GetShamsiYearToStringAsync(DateTime.Now));
        }
        [TestMethod]
        public async Task MonthTest()
        {
            Assert.AreEqual(11, await persianDateShamsi.GetShamsiMonthAsync(DateTime.Now));
        }
        [TestMethod]
        public async Task MonthStringTest()
        {
            Assert.AreEqual("11", await persianDateShamsi.GetShamsiMonthStringAsync(DateTime.Now));
        }
        [TestMethod]
        public async Task MonthNameTest()
        {
            Assert.AreEqual("بهمن", await persianDateShamsi.GetShamsiMonthNameAsync(DateTime.Now));
        }
        [TestMethod]
        public async Task DayTest()
        {
            Assert.AreEqual(3, await persianDateShamsi.GetShamsiDayAsync(DateTime.Now));
        }
        [TestMethod]
        public async Task DayStringTest()
        {
            Assert.AreEqual("03", await persianDateShamsi.GetShamsiDayStringAsync(DateTime.Now));
        }
        [TestMethod]
        public async Task DayNameTest()
        {
            Assert.AreEqual("پنجشنبه", await persianDateShamsi.GetShamsiDayNameAsync(DateTime.Now));
        }
        [TestMethod]
        public async Task DayShortNameTest()
        {
            Assert.AreEqual("پ", await persianDateShamsi.GetShamsiDayShortNameAsync(DateTime.Now));
        }
    }
}
