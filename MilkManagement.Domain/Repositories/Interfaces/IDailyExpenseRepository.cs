using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Domain.Repositories.Interfaces
{
   public interface IDailyExpenseRepository
    {
        Task<IEnumerable<ExpenseRateResponseDto>> GetAll();
        Task<IEnumerable<ExpenseRateResponseDto>> GetExpenseByExpenseIdAndDate(int expenseId, DateTime datetime);
        Task<IEnumerable<ExpenseRateResponseDto>> GetExpenseByExpenseIdWithToAndFromDate(int expenseId, DateTime fromDate, DateTime toDate);
        Task<IEnumerable<ExpenseRateResponseDto>> GetAllExpenseByDate(DateTime date);
        Task<IEnumerable<ExpenseRateResponseDto>> GetAllByToAndFromDate(DateTime fromDate, DateTime toDate);
        Task<bool> IsExpenseInsertedOnCurrentDate(int expenseId, DateTime date);
        Task<bool> IsExpenseInsertedOnCurrentDate(int expenseId, int expenseRateId, DateTime date);
        Task<IEnumerable<DailyExpenseDropdownDto>> GetDrpDown(DateTime date);
    }
}
