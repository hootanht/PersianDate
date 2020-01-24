using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PersianDate;

namespace PersianDateTests
{
    [TestClass]
    public class ToShamsiTest
    {
        //My Birthday
        DateTime dateTime = new DateTime(1998, 1, 11);
        [TestMethod]
        public async Task ToShamsiDateAsyncTest()
        {
            Assert.AreEqual("1376/10/21", await dateTime.ToShamsiDateAsync());
        }
        [TestMethod]
        public async Task ToShortShamsiDateAsyncTest()
        {
            Assert.AreEqual("76/10/21", await dateTime.ToShortShamsiDateAsync());
        }
        [TestMethod]
        public async Task ToLongShamsiDateAsyncTest()
        {
            Assert.AreEqual("يكشنبه 21 دی 1376", await dateTime.ToLongShamsiDateAsync());
        }
    }
}
