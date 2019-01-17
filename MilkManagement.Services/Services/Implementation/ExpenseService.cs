using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Customer;
using MilkManagement.Domain.Entities.Expense;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Services.Services.Implementation
{
   public class ExpenseService:IExpenseService
    {
        private readonly IAsyncRepository<Expense> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;


        public ExpenseService(IAsyncRepository<Expense> asyncRepository, IMapper mapper,IExpenseRepository expenseRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }

        public async Task<ResponseMessageDto> Post(ExpenseRequestDto dto)
        {
            try
            {
                if (!await _expenseRepository.IsExpenseNameAvailable(dto.ExpenseName))
                {
                    var expense = await _asyncRepository.AddAsync(_mapper.Map<Expense>(dto));

                    return new ResponseMessageDto()
                    {
                        Id = expense.Id,
                        SuccessMessage = ResponseMessages.InsertionSuccessMessage,
                        Success = true,
                        Error = false,
                    };
                }
                return new ResponseMessageDto()
                {
                    FailureMessage = ResponseMessages.ExpenseNameNotAvailable,
                    Success = false,
                    Error = true
                };


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    FailureMessage = ResponseMessages.InsertionFailureMessage,
                    Error = true,
                    Success = false
                };
            }
        }

        public async Task<ResponseMessageDto> UpdateExpense(ExpenseRequestDto dto)
        {
            try
            {
                if (!await _expenseRepository.IsExpenseNameAvailable(dto.Id, dto.ExpenseName))
                {
                     await _asyncRepository.UpdateAsync(_mapper.Map<Expense>(dto));
                    return new ResponseMessageDto()
                    {
                        Id =dto.Id,
                        Success = true,
                        SuccessMessage = ResponseMessages.UpdateSuccessMessage,
                        Error = false
                    };
                }
                return new ResponseMessageDto()
                {
                    FailureMessage = ResponseMessages.ExpenseNameNotAvailable,
                    Success = false,
                    Error = true
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    FailureMessage = ResponseMessages.UpdateFailureMessage,
                    Error = true,
                    Success = false
                };
            }
        }

        public async Task<ResponseMessageDto> DeleteExpense(ExpenseRequestDto dto)
        {
            try
            {
                await _asyncRepository.DeleteAsync(_mapper.Map<Expense>(dto));
                return new ResponseMessageDto()
                {
                    Id = dto.Id,
                    Success = true,
                    SuccessMessage = ResponseMessages.DeleteSuccessMessage,
                    Error = false
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    FailureMessage = ResponseMessages.DeleteFailureMessage,
                    Error = true,
                    Success = false
                };
            }
        }

        public async Task<IEnumerable<ExpenseResponseDto>> GetAll()
        {
            try
            {
                return await _asyncRepository.ListAllAsync<ExpenseResponseDto>();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //public  ExpenseResponseDto GetById(int expenseId)
        //{
        //    try
        //    {
        //        var res=  _repository.GetById(expenseId);
        //        return res;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

        //public async Task<IEnumerable<ExpenseResponseDto>> GetByName(string expenseName)
        //{
        //    try
        //    {
        //        return await _expenseRepository.GetByName(expenseName);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

        public async Task<bool> IsExpenseNameAvailable(string expenseName)
        {
            return await _expenseRepository.IsExpenseNameAvailable(expenseName);
        }
    }
}
