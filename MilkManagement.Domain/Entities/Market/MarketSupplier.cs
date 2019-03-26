using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MilkManagement.Domain.Entities.Market
{
    public class MarketSupplier : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string MarketSupplierName { get; set; }
        [Required]
        [MaxLength(150)]
        public string MarketSupplierAddress { get; set; }
        [Required]
        [MaxLength(150)]
        public string MarketSupplierContact { get; set; }
    }
}
