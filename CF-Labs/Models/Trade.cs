using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CF_Labs.Models
{
    public class Trade
    {
        public int TradeId { get; set; }

        /// <summary>
        /// better to use enum here, faster to compare enums than strings, given that there's only 2 options: Buy or Sell.
        /// </summary>

        [JsonProperty("Direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Directions Direction { get; set; }

        public enum Directions{ Buy, Sell}  

        public int Quantity { get; set; }

        /// <summary>
        /// I feel like this should really be a decimal since we are dealing with money 
        /// </summary>
        public double Price { get; set; }

        public string Underlying  { get; set; }

    }
}
