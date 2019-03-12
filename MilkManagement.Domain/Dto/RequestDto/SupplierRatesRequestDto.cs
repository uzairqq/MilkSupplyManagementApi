using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto.RequestDto
{
   public class SupplierRatesRequestDto:BaseEntity
    {
        public int SupplierId { get; set; }
        public int CurrentRate { get; set; }
        public int PreviousRate { get; set; }
    }
}
