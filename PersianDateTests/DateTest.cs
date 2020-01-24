using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersianDate;
using System;

namespace PersianDateTests
{
    [TestClass]
    public class DateTest
    {
        //My Birthday
        DateTime dateTime = new DateTime(1998, 1, 11);
        PersianDateShamsi persianDateShamsi = new PersianDateShamsi();
        [TestMethod]
        public void YearTest()
        {
            Assert.AreEqual(1376, persianDateShamsi.GetShamsiYear(dateTime));
        }
        [TestMethod]
        public void ShortYearTest()
        {
            Assert.AreEqual("76", persianDateShamsi.GetShortShamsiYear(dateTime));
        }
        [TestMethod]
        public void YearStringTest()
        {
            Assert.AreEqual("1376", persianDateShamsi.GetShamsiYearToString(dateTime));
        }
        [TestMethod]
        public void MonthTest()
        {
            Assert.AreEqual(10, persianDateShamsi.GetShamsiMonth(dateTime));
        }
        [TestMethod]
        public void MonthStringTest()
        {
            Assert.AreEqual("10", persianDateShamsi.GetShamsiMonthString(dateTime));
        }
        [TestMethod]
        public void MonthNameTest()
        {
            Assert.AreEqual("دی", persianDateShamsi.GetShamsiMonthName(dateTime));
        }
        [TestMethod]
        public void DayTest()
        {
            Assert.AreEqual(21, persianDateShamsi.GetShamsiDay(dateTime));
        }
        [TestMethod]
        public void DayStringTest()
        {
            Assert.AreEqual("21", persianDateShamsi.GetShamsiDayString(dateTime));
        }
        [TestMethod]
        public void DayNameTest()
        {
            Assert.AreEqual("يكشنبه", persianDateShamsi.GetShamsiDayName(dateTime));
        }
        [TestMethod]
        public void DayShortNameTest()
        {
            Assert.AreEqual("ي", persianDateShamsi.GetShamsiDayShortName(dateTime));
        }
    }
}
