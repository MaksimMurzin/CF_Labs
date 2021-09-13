using CF_Labs.Models;
using System.Collections.Generic;

namespace CF_Labs
{
    public static class ProfitCounter
    {
        static public double  CalcultateTotal(IEnumerable<Trade> trades)
        {
            double total = 0;
            foreach (var trade in trades)
            {
                total += trade.Price * trade.Quantity;
            }
            return total;
        }

         public static double CalculatePNL(IEnumerable<Trade> allBuys, IEnumerable<Trade> allSells) 
            => CalcultateTotal(allSells) - CalcultateTotal(allBuys);
   

    }
}
