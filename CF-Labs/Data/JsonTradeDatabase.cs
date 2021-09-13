using CF_Labs.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CF_Labs.Data
{
    public class JsonTradeDatabase : ITradesDatabase
    {
        //in case you ever want to stringify some objects into json 
        ////string json = JsonConvert.SerializeObject(mockDb.GetAllTrades(), Formatting.Indented);

        public string URL { get; set; }
        public string MainPath { get; set; }
        public IEnumerable<Trade> Trades { get; private set; }

        public JsonTradeDatabase()
        {
            // this is a bit of a workaround but it'll do
            URL = System.IO.Path.GetFullPath(".\\");
            ////correction in path to point it in Root directory
            MainPath = Path.Combine(URL, "Data/JsonData.json");
            Trades = JsonConvert.DeserializeObject<List<Trade>>(File.ReadAllText(MainPath));
        }

        public IEnumerable<Trade> GetAllTrades() => Trades;

        public Trade GetTradeById(int id) => Trades.FirstOrDefault(trade => trade.TradeId == id);
    }
}
