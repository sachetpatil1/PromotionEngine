using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PromotionEngine
{
    [TestClass]
    public class PromotionTests
    {
        Promotion pr = new Promotion();
        [TestMethod]
        public void TestMethod1()
        {
            int TotalPrice = 0;
            Dictionary<string, int> CartDetail = new Dictionary<string, int>();
            CartDetail.Add("A",1);
            CartDetail.Add("B", 1);
            CartDetail.Add("C", 1);

            TotalPrice = pr.GetCartPrice(CartDetail);
            Assert.AreEqual(100, TotalPrice);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int TotalPrice = 0;
            Dictionary<string, int> CartDetail = new Dictionary<string, int>();
            CartDetail.Add("A", 5);
            CartDetail.Add("B", 5);
            CartDetail.Add("C", 1);

            TotalPrice = pr.GetCartPrice(CartDetail);
            Assert.AreEqual(370, TotalPrice);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int TotalPrice = 0;
            Dictionary<string, int> CartDetail = new Dictionary<string, int>();
            CartDetail.Add("A", 3);
            CartDetail.Add("B", 5);
            CartDetail.Add("C", 1);
            CartDetail.Add("D", 1);

            TotalPrice = pr.GetCartPrice(CartDetail);
            Assert.AreEqual(280, TotalPrice);
        }
    }
}
