using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MilkManagement.Core.Validator;

namespace MilkManagement.Domain.Entities.Customer
{
   public class Customer:BaseEntity,ISoftDeletable
    {
        public Customer()
        {
            CustomerRates = new HashSet<CustomerRates>();
            CustomerSupplied = new HashSet<CustomerSupplied>();
        }

      

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(1025)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Contact { get; set; }

        public int CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }

        public bool IsDeleted { get; set; }


        public virtual ICollection<CustomerRates> CustomerRates { get; set; }
        public virtual ICollection<CustomerSupplied> CustomerSupplied { get; set; }
    }
}
