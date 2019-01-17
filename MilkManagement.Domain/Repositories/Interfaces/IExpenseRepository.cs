using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Domain.Repositories.Interfaces
{
   public interface IExpenseRepository
    {
        Task<bool> IsExpenseNameAvailable(string expenseName);
        Task<bool> IsExpenseNameAvailable(int expenseId, string expenseName);
    }
}
