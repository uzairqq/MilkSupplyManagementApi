using MilkManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Dto.ResponseDto
{
   public class MarketSellResponseDto:BaseEntity
    {
        public int MarketSupplierId { get; set; }
        public string MorningSell { get; set; }
        public string MorningAmount { get; set; }
        public string MorningRate { get; set; }
        public string AfternoonSell { get; set; }
        public string AfternoonAmount { get; set; }
        public string AfternoonRate { get; set; }
        public string TotalAmount { get; set; }
        public int ComissionRate { get; set; }
        public int? TotalComission { get; set; }
        public string TotalMilk { get; set; }
        public string MarketSupplierName { get;  set; }
    }
}
