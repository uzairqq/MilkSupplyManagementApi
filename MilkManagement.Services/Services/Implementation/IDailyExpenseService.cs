using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Services.Services.Implementation
{
   public interface IDailyExpenseService
    {
        Task<ResponseMessageDto> Post(ExpenseRateRequestDto dto);
        Task<ResponseMessageDto> Put(ExpenseRateRequestDto dto);
        Task<ResponseMessageDto> Delete(ExpenseRateRequestDto dto);
        Task<IEnumerable<ExpenseRateResponseDto>> GetAll();
        Task<IEnumerable<ExpenseRateResponseDto>> GetExpenseByExpenseIdAndDate(int expenseId, DateTime dateTime);
        Task<IEnumerable<ExpenseRateResponseDto>> GetExpenseByExpenseIdWithToAndFromDate(int expenseId, DateTime fromDate, DateTime toDate);
        Task<IEnumerable<ExpenseRateResponseDto>> GetAllExpenseByDate(DateTime date);
        Task<IEnumerable<ExpenseRateResponseDto>> GetAllByToAndFromDate(DateTime fromDate, DateTime toDate);
        Task<IEnumerable<DailyExpenseDropdownDto>> GetDrpDown(DateTime date);
        Task<ResponseMessageDto> ListPost(IEnumerable<ExpenseRateRequestDto> dto,DateTime date);
    }
}
