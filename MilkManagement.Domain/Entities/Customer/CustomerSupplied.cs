using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MilkManagement.Core.Validator;

namespace MilkManagement.Domain.Entities.Customer
{
    public class CustomerSupplied : BaseEntity
    {
        public int CustomerTypeId { get; set; }
        public int CustomerId { get; set; }
        public string MorningSupply { get; set; }
        public string AfternoonSupply { get; set; }
        public double MorningAmount { get; set; }
        public double AfternoonAmount { get; set; }
        public int Rate { get; set; }
        public float? Debit { get; set; }
        public float? Credit { get; set; }
        public double? Total { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual CustomerType CustomerType { get; set; }




    }
}
