using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MilkManagement.Core.Validator;

namespace MilkManagement.Domain.Entities.Supplier
{
   public class Supplier:BaseEntity
    {
        //public Supplier()
        //{
        //    SupplierRates = new HashSet<SupplierRates>();
        //    SupplierSupplied = new HashSet<SupplierSupplied>();
        //}

        [StringLength(255)]
        [Required]
        public string SupplierName { get; set; }
        [StringLength(1025)]
        public string SupplierContact { get; set; }
        [StringLength(20)]
        public string SupplierAddress { get; set; }

        //public virtual ICollection<SupplierRates> SupplierRates { get; set; }
        //public virtual ICollection<SupplierSupplied> SupplierSupplied { get; set; }
    }
}
