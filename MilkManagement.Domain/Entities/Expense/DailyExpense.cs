using System;
using System.Collections.Generic;
using System.Text;

namespace MilkManagement.Domain.Entities.Expense
{
    public class DailyExpense:BaseEntity
    {
        public int ExpenseId { get; set; }
        public string Rate { get; set; }
        public  Expense Expense { get; set; }
    }
}
