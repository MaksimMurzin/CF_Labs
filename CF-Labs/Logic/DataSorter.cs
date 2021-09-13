using CF_Labs.Data;
using CF_Labs.Models;
using System.Collections.Generic;
using System.Linq;

namespace CF_Labs
{
    public class DataSorter
    {
        public ITradesDatabase _Db { get; }

        public DataSorter(ITradesDatabase db)
        {
            _Db = db;
        }
        public IEnumerable<Trade> GetAllBuys() => _Db.GetAllTrades().Where(trade => trade.Direction == Models.Trade.Directions.Buy);
        public IEnumerable<Trade> GetAllSells() => _Db.GetAllTrades().Where(trade => trade.Direction == Models.Trade.Directions.Sell);
    }
}
