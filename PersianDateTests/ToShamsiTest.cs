using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PersianDate;

namespace PersianDateTests
{
    [TestClass]
    public class ToShamsiTest
    {
        //My Birthday
        DateTime? dateTime = new DateTime(1998, 1, 11);
        [TestMethod]
        public void ToShamsiDateTest()
        {
            Assert.AreEqual("1376/10/21", dateTime.ToShamsiDate());
        }
        [TestMethod]
        public void ToShortShamsiDateTest()
        {
            Assert.AreEqual("76/10/21", dateTime.ToShortShamsiDate());
        }
        [TestMethod]
        public void ToLongShamsiDateTest()
        {
            Assert.AreEqual("یکشنبه 21 دی 1376", dateTime.ToLongShamsiDate());
        }

        // Additional test methods for edge cases and invalid inputs
        [TestMethod]
        public void NullDateTimeTest()
        {
            DateTime? nullDateTime = null;
            Assert.IsNull(nullDateTime.ToShamsiDate());
            Assert.IsNull(nullDateTime.ToShortShamsiDate());
            Assert.IsNull(nullDateTime.ToLongShamsiDate());
        }

        [TestMethod]
        public void MinDateTimeTest()
        {
            DateTime minDateTime = DateTime.MinValue;
            Assert.AreEqual("1/1/1", minDateTime.ToShamsiDate());
            Assert.AreEqual("01/01/01", minDateTime.ToShortShamsiDate());
            Assert.AreEqual("شنبه 1 فروردین 1", minDateTime.ToLongShamsiDate());
        }

        [TestMethod]
        public void MaxDateTimeTest()
        {
            DateTime maxDateTime = DateTime.MaxValue;
            Assert.AreEqual("9378/10/13", maxDateTime.ToShamsiDate());
            Assert.AreEqual("78/10/13", maxDateTime.ToShortShamsiDate());
            Assert.AreEqual("جمعه 13 دی 9378", maxDateTime.ToLongShamsiDate());
        }
    }
}
