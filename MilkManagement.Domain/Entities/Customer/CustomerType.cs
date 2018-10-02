using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MilkManagement.Domain.Entities.Customer
{
    public class CustomerType : BaseEntity
    {
        [StringLength(10)]
        public string Type { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
