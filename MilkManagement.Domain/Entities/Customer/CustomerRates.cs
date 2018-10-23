using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MilkManagement.Core.Validator;

namespace MilkManagement.Domain.Entities.Customer
{
   public class CustomerRates:BaseEntity,ISoftDeletable
    {
        public CustomerRates()
        {
            
        }
      
        public int CustomerId { get; set; }
        public int CurrentRate { get; set; }
        public int PreviousRate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedById { get; set; }

        public bool IsDeleted { get; set; }

       
        public Customer Customer { get; set; }
    }
}
