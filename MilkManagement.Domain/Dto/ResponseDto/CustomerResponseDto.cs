using System;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto.ResponseDto
{
   public class CustomerResponseDto:BaseEntity
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public int CustomerTypeId { get; set; }

        public string Type { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public int CreatedById { get; set; }
        
        public DateTime LastUpdatedOn { get; set; }
        
        public int LastUpdatedById { get; set; }
    }
}
