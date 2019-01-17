using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MilkManagement.Domain.Entities;
using MilkManagement.Domain.Entities.Customer;

namespace MilkManagement.Domain.Dto.RequestDto
{
    public class CustomerSuppliedRequestDto : BaseEntity
    {
        public int CustomerId { get; set; }
        public string MorningSupply { get; set; }
        public string AfternoonSupply { get; set; }
        public double MorningAmount { get; set; }
        public double AfternoonAmount { get; set; }
        public float? Rate { get; set; }
        public float? Debit { get; set; }
        public float? Credit { get; set; }
        public double? Total { get; set; }
   


    }
}
