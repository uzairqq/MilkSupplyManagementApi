using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities;

namespace MilkManagement.Domain.Dto.ResponseDto
{
    public class ExpenseRateResponseDto : BaseEntity
    {
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public string Rate { get; set; }
    }
}
