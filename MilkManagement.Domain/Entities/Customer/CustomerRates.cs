using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MilkManagement.Domain.Entities.Customer
{
   public class CustomerRates:BaseEntity
    {
      
        public int CurrentRate { get; set; }
        public int PreviousRate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public int? LastUpdatedById { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
