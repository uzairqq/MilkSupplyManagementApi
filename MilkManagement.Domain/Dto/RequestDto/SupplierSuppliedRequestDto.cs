using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities;
using MilkManagement.Domain.Entities.Supplier;

namespace MilkManagement.Domain.Dto.RequestDto
{
   public class SupplierSuppliedRequestDto:BaseEntity
    {
        public int SupplierId { get; set; }
        public string MorningPurchase { get; set; }
        public string AfternoonPurchase { get; set; }
        public string MorningAmount { get; set; }
        public string AfternoonAmount { get; set; }
        public int Rate { get; set; }
        public string Total { get; set; }

    }
}
