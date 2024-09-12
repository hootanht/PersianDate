using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersianDate;
using System;

namespace PersianDateTests
{
    [TestClass]
    public class DateTest
    {
        //My Birthday
        DateTime? dateTime = new DateTime(1998, 1, 11);
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
            Assert.AreEqual("10", persianDateShamsi.GetShamsiMonthString(dateTime.Value));
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
            Assert.IsNull(persianDateShamsi.GetShamsiMonthNumber(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiMonthName(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiDay(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiDayString(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiDayName(nullDateTime));
            Assert.IsNull(persianDateShamsi.GetShamsiDayShortName(nullDateTime));
        }

        [TestMethod]
        public void MinDateTimeTest()
        {
            DateTime? minDateTime = DateTime.MinValue;
            Assert.AreEqual("0001/10/11", minDateTime.ToShamsiDate());
            Assert.AreEqual("01/10/11", minDateTime.ToShortShamsiDate());
            Assert.AreEqual("جمعه 11 دی 1", minDateTime.ToLongShamsiDate());
        }

        [TestMethod]
        public void MaxDateTimeTest()
        {
            DateTime? maxDateTime = DateTime.MaxValue;
            Assert.AreEqual("9378/10/13", maxDateTime.ToShamsiDate());
            Assert.AreEqual("78/10/13", maxDateTime.ToShortShamsiDate());
            Assert.AreEqual("جمعه 13 دی 9378", maxDateTime.ToLongShamsiDate());
        }
    }
}
