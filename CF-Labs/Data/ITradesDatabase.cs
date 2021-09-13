using CF_Labs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF_Labs.Data
{
    public interface ITradesDatabase
    {
        IEnumerable<Trade> GetAllTrades();


        Trade GetTradeById(int id);


    }
}
