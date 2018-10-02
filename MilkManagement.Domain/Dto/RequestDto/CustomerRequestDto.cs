using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto.RequestDto
{
   public class CustomerRequestDto:BaseEntity
    {
        public int CustomerTypeId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        
        public DateTime CreatedOn { get; set; }

        public int CreatedById { get; set; }
        
        public DateTime LastUpdatedOn { get; set; }
        
        public int LastUpdatedById { get; set; }
        
    }
}
