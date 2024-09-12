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
            Assert.AreEqual("یکشنبه", persianDateShamsi.GetShamsiDayName(dateTime));
        }
        [TestMethod]
        public void DayShortNameTest()
        {
            Assert.AreEqual("ی", persianDateShamsi.GetShamsiDayShortName(dateTime));
        }

        // Additional test methods for edge cases and invalid inputs
        [TestMethod]
        public void NullDateTimeTest()
        {
            DateTime? nullDateTime = null;
            Assert.IsNull(persianDateShamsi.GetShamsiYear(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShortShamsiYear(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiYearToString(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiMonth(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiMonthBunber(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiMonthName(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiDay(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiDayString(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiDayName(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiDayShortName(nullDateTime));
        }

        [TestMethod]
        public void MinDateTimeTest()
        {
            DateTime minDateTime = DateTime.MinValue;
            Assert.AreEqual(1, persianDateShamsi.GetShamsiYear(minDateTime));
            Assert.AreEqual("01", persianDateShamsi.GetShortShamsiYear(minDateTime));
            Assert.AreEqual("1", persianDateShamsi.GetShamsiYearToString(minDateTime));
            Assert.AreEqual(1, persianDateShamsi.GetShamsiMonth(minDateTime));
            Assert.AreEqual("01", persianDateShamsi.GetShamsiMonthString(minDateTime));
            Assert.AreEqual<int>(1, persianDateShamsi.GetShamsiMonthBunber(minDateTime));
            Assert.AreEqual("فروردین", persianDateShamsi.GetShamsiMonthName(minDateTime));
            Assert.AreEqual(1, persianDateShamsi.GetShamsiDay(minDateTime));
            Assert.AreEqual("01", persianDateShamsi.GetShamsiDayString(minDateTime));
            Assert.AreEqual("شنبه", persianDateShamsi.GetShamsiDayName(minDateTime));
            Assert.AreEqual("ش", persianDateShamsi.GetShamsiDayShortName(minDateTime));
        }

        [TestMethod]
        public void MaxDateTimeTest()
        {
            DateTime maxDateTime = DateTime.MaxValue;
            Assert.AreEqual(9378, persianDateShamsi.GetShamsiYear(maxDateTime));
            Assert.AreEqual("78", persianDateShamsi.GetShortShamsiYear(maxDateTime));
            Assert.AreEqual("9378", persianDateShamsi.GetShamsiYearToString(maxDateTime));
            Assert.AreEqual(10, persianDateShamsi.GetShamsiMonth(maxDateTime));
            Assert.AreEqual("10", persianDateShamsi.GetShamsiMonthString(maxDateTime));
            Assert.AreEqual<int>(10, persianDateShamsi.GetShamsiMonthBunber(maxDateTime));
            Assert.AreEqual("دی", persianDateShamsi.GetShamsiMonthName(maxDateTime));
            Assert.AreEqual(13, persianDateShamsi.GetShamsiDay(maxDateTime));
            Assert.AreEqual("13", persianDateShamsi.GetShamsiDayString(maxDateTime));
            Assert.AreEqual("جمعه", persianDateShamsi.GetShamsiDayName(maxDateTime));
            Assert.AreEqual("ج", persianDateShamsi.GetShamsiDayShortName(maxDateTime));
        }
    }
}
