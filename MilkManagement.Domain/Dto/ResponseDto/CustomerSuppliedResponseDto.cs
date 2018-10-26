using MilkManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Dto.ResponseDto
{
   public class CustomerSuppliedResponseDto:BaseEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string MorningSupply { get; set; }
        public string AfternoonSupply { get; set; }
        public double MorningAmount { get; set; }
        public double AfternoonAmount { get; set; }
        public float? Rate { get; set; }
        public float? Debit { get; set; }
        public float? Credit { get; set; }
        public double? Total { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedById { get; set; }
    }
}
