using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MilkManagement.Core.Validator;

namespace MilkManagement.Domain.Entities.Expense
{
   public class Expense : BaseEntity, ISoftDeletable
    {
        [StringLength(255)]
        [Required]
        public string ExpenseName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
