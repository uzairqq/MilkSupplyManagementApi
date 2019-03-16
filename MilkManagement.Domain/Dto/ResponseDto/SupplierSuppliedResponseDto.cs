using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto.ResponseDto
{
   public class SupplierSuppliedResponseDto:BaseEntity
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string MorningPurchase { get; set; }
        public string AfternoonPurchase { get; set; }
        public string MorningAmount { get; set; }
        public string AfternoonAmount { get; set; }
        public int Rate { get; set; }
        public string Total { get; set; }
    }
}
