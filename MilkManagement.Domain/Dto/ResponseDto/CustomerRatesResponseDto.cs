using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto
{
   public class CustomerRatesResponseDto:BaseEntity
    {
        
        public int CurrentRate { get; set; }
        public int PreviousRate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedById { get; set; }
        public string CustomerName { get; set; }
     
        public int CustomerId { get; set; }
    }
}
