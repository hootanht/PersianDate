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
    }
}
