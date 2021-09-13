using CF_Labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_Labs.Data
{
    public class MockTradeDatabase : ITradesDatabase
    {
        private List<Trade> AllTrades = new List<Trade>() 
        {
            new Trade{TradeId = 1,  Direction = Trade.Directions.Buy, Quantity = 2, Price = 100, Underlying = "Oil"  },
            new Trade{TradeId = 2,  Direction = Trade.Directions.Buy, Quantity = 2, Price = 110, Underlying = "Oil"  },
            new Trade{TradeId = 3,  Direction = Trade.Directions.Buy, Quantity = 2, Price = 102, Underlying = "Oil"  },
            new Trade{TradeId = 4,  Direction = Trade.Directions.Sell, Quantity = 6, Price = 102, Underlying = "Index Fund"  }
        };

        public IEnumerable<Trade> GetAllTrades() => AllTrades;

        public Trade GetTradeById(int id) => AllTrades.FirstOrDefault(trade => trade.TradeId == id);
    }
}
