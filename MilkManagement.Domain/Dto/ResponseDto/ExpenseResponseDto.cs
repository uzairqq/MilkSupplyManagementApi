using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto.ResponseDto
{
   public class ExpenseResponseDto:BaseEntity
    {
        public string ExpenseName { get; set; }
    }
}
