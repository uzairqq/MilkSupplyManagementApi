using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Services.Services.Interfaces
{
    public interface IExpenseService
    {
        Task<ResponseMessageDto> Post(ExpenseRequestDto dto);
        Task<ResponseMessageDto> UpdateExpense(ExpenseRequestDto dto);
        Task<ResponseMessageDto> DeleteExpense(ExpenseRequestDto dto);
        Task<IEnumerable<ExpenseResponseDto>> GetAll();
        //Task<ExpenseResponseDto> GetById(int expenseId);
        //Task<IEnumerable<ExpenseResponseDto>> GetByName(string expenseName);
        Task<bool> IsExpenseNameAvailable(string expenseName);
    }
}
