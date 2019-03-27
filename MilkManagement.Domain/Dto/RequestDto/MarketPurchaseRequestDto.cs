using MilkManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Dto.RequestDto
{
   public class MarketPurchaseRequestDto:BaseEntity
    {
        public int MarketSupplierId { get; set; }
        public string MorningPurchase { get; set; }
        public int MorningRate { get; set; }
        public string MorningAmount { get; set; }
        public string AfternoonPurchase { get; set; }
        public int AfternoonRate { get; set; }
        public string AfternoonAmount { get; set; }
        public int TotalAmount { get; set; }
        public string TotalMilk  { get; set; }

    }
}
