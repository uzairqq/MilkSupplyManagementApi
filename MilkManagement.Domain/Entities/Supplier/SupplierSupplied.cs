using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Entities.Supplier
{
   public class SupplierSupplied:BaseEntity
    {
        public int SupplierId { get; set; }
        public string MorningPurchase { get; set; }
        public string AfternoonPurchase { get; set; }
        public string MorningAmount { get; set; }
        public string AfternoonAmount { get; set; }
        public int Rate { get; set; }
        public string Total { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
