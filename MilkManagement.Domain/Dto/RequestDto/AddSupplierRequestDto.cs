using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto.RequestDto
{
   public class AddSupplierRequestDto:BaseEntity
    {
        public string SupplierName { get; set; }
        public string SupplierContact { get; set; }
        public string SupplierAddress { get; set; }
    }
}
