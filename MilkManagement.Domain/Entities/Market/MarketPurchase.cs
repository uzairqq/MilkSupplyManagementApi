using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Entities.Market
{
   public class MarketPurchase:BaseEntity
    {
        public int MarketSupplierId { get; set; }
        public string MorningPurchase { get; set; }
        public int MorningRate { get; set; }
        public string MorningAmount { get; set; }
        public string AfternoonPurchase { get; set; }
        public int AfternoonRate { get; set; }
        public string AfternoonAmount { get; set; }
        public int Total { get; set; }

        public MarketSupplier MarketSupplier { get; set; }
    }
}
