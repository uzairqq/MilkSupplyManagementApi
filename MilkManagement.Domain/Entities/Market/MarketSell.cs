using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Entities.Market
{
   public class MarketSell:BaseEntity
    {
        public int MarketSupplierId { get; set; }
        public string MorningSell { get; set; }
        //[JsonIgnore]
        public string MorningAmount { get; set; }
        public string MorningRate { get; set; }
        public string AfternoonSell { get; set; }
        //[JsonIgnore]
        public string AfternoonAmount { get; set; }
        public string AfternoonRate { get; set; }
        //[JsonIgnore]
        public string Total { get; set; }
        public int ComissionRate { get; set; }
        //[JsonIgnore]
        public int? TotalComission { get; set; }
        //[JsonIgnore]
        public string TotalMilk { get; set; }

        public MarketSupplier MarketSupplier { get; set; }
    }
}
