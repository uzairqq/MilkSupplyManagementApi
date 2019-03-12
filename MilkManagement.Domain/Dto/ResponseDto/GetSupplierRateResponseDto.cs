using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto.ResponseDto
{
   public class GetSupplierRateResponseDto:BaseEntity
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int CurrentRate { get; set; }
        public int PreviousRate { get; set; }
    
    }
}
