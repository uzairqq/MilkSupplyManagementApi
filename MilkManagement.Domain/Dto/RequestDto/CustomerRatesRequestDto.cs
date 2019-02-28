using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto.RequestDto
{
   public class CustomerRatesRequestDto:BaseEntity
    {
        public int CustomerId { get; set; }
        public string CurrentRate { get; set; }
        public string PreviousRate { get; set; }

    }
}
