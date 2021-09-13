﻿using CF_Labs.Models;
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
        
        
        private IEnumerable<Trade> _Trades { get; set; }

        private const string path = @"C:\Users\Makos_PC\Desktop\CF-Labs\CF-Labs\Data\JsonData.json";
        public JsonTradeDatabase()
        {
            //I need to figure out how to change this static path to a dynamic one
            /*string solutionPath = AppDomain.CurrentDomain.BaseDirectory; //Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName; */


            _Trades = JsonConvert.DeserializeObject<List<Trade>>(File.ReadAllText(path));
        }

        public IEnumerable<Trade> GetAllTrades() => _Trades;

        public Trade GetTradeById(int id) => _Trades.FirstOrDefault(trade => trade.TradeId == id);
    }
}