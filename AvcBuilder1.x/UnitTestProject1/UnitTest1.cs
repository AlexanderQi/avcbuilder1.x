using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AvcDb.entities;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            tblalarm a = new tblalarm();
            tblalarm b = new tblalarm();

            
            a.ID = 11;
            a.aContent = "adadsf";
            b.aContent = "--------------------" + a.aContent;
            Console.WriteLine("content:  " + b.aContent);

        }
    }
}
