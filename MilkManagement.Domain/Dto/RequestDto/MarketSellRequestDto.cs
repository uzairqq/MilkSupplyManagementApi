﻿using MilkManagement.Domain.Entities;
using MilkManagement.Domain.Entities.Market;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Dto.RequestDto
{
   public class MarketSellRequestDto:BaseEntity
    {
        public int MarketSupplierId { get; set; }
        public string MorningSell { get; set; }
        public string MorningAmount { get; set; }
        public string MorningRate { get; set; }
        public string AfternoonSell { get; set; }
        public string AfternoonAmount { get; set; }
        public string AfternoonRate { get; set; }
        public string Total { get; set; }
        public int ComissionRate { get; set; }
        public int? TotalComission { get; set; }
        public string TotalMilk { get; set; }
    }
}
