using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Dto.ResponseDto
{
   public class CustomerResponseDto
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public int CreatedById { get; set; }
        
        public DateTime LastUpdatedOn { get; set; }
        
        public int LastUpdatedById { get; set; }
        
    }
}
