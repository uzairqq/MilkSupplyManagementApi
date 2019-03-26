using MilkManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Dto.ResponseDto
{
   public class MarketSupplierResponseDto:BaseEntity
    {
        public string MarketSupplierName { get; set; }

        public string MarketSupplierAddress { get; set; }

        public string MarketSupplierContact { get; set; }
    }
}
