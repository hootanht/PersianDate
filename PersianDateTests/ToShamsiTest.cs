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
        [TestMethod]
        public async Task ToShamsiDateTest()
        {
            Assert.AreEqual("1398/11/03",await DateTime.Now.ToShamsiDate());
        }
        [TestMethod]
        public async Task ToShortShamsiDateTest()
        {
            Assert.AreEqual("98/11/03", await DateTime.Now.ToShortShamsiDate());
        }
        [TestMethod]
        public async Task ToLongShamsiDateTest()
        {
            Assert.AreEqual("پنجشنبه 3 بهمن 1398", await DateTime.Now.ToLongShamsiDate());
        }
    }
}
