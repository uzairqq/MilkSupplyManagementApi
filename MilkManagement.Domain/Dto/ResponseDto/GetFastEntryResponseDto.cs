using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Dto.ResponseDto
{
   public class GetFastEntryResponseDto
    {
        public string CustomerName{ get; set; }
        public string MorningSupply { get; set; }
        public string AfternoonSupply { get; set; }
        public string CustomerType { get; set; }
        public int CustomerId { get; set; }
        public int CustomerTypeId { get; set; }
    }
}
