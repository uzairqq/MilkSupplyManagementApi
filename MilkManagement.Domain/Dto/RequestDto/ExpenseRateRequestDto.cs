using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto.RequestDto
{
   public class ExpenseRateRequestDto:BaseEntity
    {
        public int ExpenseId { get; set; }
        public string Rate { get; set; }
    }
}
