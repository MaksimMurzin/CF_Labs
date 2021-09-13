using CF_Labs.Models;
using CF_Labs.Data;
using CF_Labs;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApplicationTests
{
   [TestClass]
    public class MyTestClass
    {

        ITradesDatabase TestDatabase { get; set; }
        IEnumerable<Trade> TestData { get; set; }
        private DataSorter DataSorter { get; set; }
        IEnumerable<Trade> Allbuys { get; set; }


        [TestInitialize]
        public void BeginTest()
        {
            Allbuys = new List<Trade>() {
            new Trade{TradeId = 1,  Direction = Trade.Directions.Buy, Quantity = 2, Price = 100, Underlying = "Oil"  },
            new Trade{TradeId = 2,  Direction = Trade.Directions.Buy, Quantity = 2, Price = 110, Underlying = "Oil"  },
            new Trade{TradeId = 3,  Direction = Trade.Directions.Buy, Quantity = 2, Price = 102, Underlying = "Oil"  }};


            TestDatabase = new MockTradeDatabase();
            DataSorter = new DataSorter(TestDatabase);
            

        }

        /// <summary>
        /// This one is more for me to know if my tests are going mad or the frameworks aren't working properly
        /// </summary>
        [TestMethod]
        public void SanityCheck()
        {
            Assert.AreEqual(2, 2);
        }
        
        [TestMethod]
        public void TestBuysAreEqualByJson()
        {
            var expectedJSON = JsonConvert.SerializeObject(Allbuys);
            var actualJSON = JsonConvert.SerializeObject(DataSorter.GetAllBuys());

            Assert.AreEqual(expectedJSON, actualJSON, "The sorting algorithm for buys is messing up");
        }

        [DataRow(624.0)]
        [TestMethod]
        public void TestCalculateTotal(double expected)
        {
            Assert.AreEqual(ProfitCounter.CalcultateTotal(DataSorter.GetAllBuys()), expected); 
        }



    }
}
