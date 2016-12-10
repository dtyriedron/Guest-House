using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cw2_cs;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //set up 
            Booking b1 = new Booking();
            Customer c1 = new Customer();
            c1.Cus_Name = "terry";
            b1.Cust = c1;
            //assert
            Assert.AreSame(b1.Cust, c1, "my customers match");
        }
    }
}
