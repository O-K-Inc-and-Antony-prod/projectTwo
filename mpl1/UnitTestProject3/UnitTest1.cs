using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mpl1;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            Assert.AreEqual(0, f.vozvedenie(3.4, 1), 0, "тест не пройден");

        }
    }
}
