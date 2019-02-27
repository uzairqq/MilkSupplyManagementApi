using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Dto.ResponseDto
{
   public class GetCustomerRatesDropDownDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerTypeId { get; set; }
        public string Type { get; set; }
    }
}
