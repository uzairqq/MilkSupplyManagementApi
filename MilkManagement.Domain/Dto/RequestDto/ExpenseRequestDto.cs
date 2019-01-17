using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto.RequestDto
{
   public class ExpenseRequestDto : BaseEntity
    {
        public string ExpenseName { get; set; }
    }
}
