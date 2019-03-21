using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Expense;
using MilkManagement.Domain.Repositories.Interfaces;

namespace MilkManagement.Services.Services.Implementation
{
    public class DailyExpenseService : IDailyExpenseService
    {
        private readonly IDailyExpenseRepository _expenseRateRepository;
        private readonly IAsyncRepository<DailyExpense> _asyncRepository;
        private readonly IMapper _mapper;

        public DailyExpenseService(IDailyExpenseRepository expenseRateRepository, IAsyncRepository<DailyExpense> asyncRepository, IMapper mapper)
        {
            _expenseRateRepository = expenseRateRepository;
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<ResponseMessageDto> Post(ExpenseRateRequestDto dto)
        {
            try
            {
                if (!await _expenseRateRepository.IsExpenseInsertedOnCurrentDate(dto.ExpenseId, dto.CreatedOn))
                {

                    var dailyExpense = await _asyncRepository.AddAsync(_mapper.Map<DailyExpense>(dto));
                    return new ResponseMessageDto()
                    {
                        Id = dailyExpense.Id,
                        SuccessMessage = ResponseMessages.InsertionSuccessMessage,
                        Success = true,
                        Error = false
                    };
                }
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    FailureMessage = ResponseMessages.ExpenseAlreadyHaveOnThisDate,
                    Success = false,
                    Error = true
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    FailureMessage = ResponseMessages.InsertionFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        public async Task<ResponseMessageDto> Put(ExpenseRateRequestDto dto)
        {
            try
            {
                if (!await _expenseRateRepository.IsExpenseInsertedOnCurrentDate(dto.ExpenseId, dto.Id, dto.CreatedOn.Date))
                {
                    //var expenseRate = await _expenseRateRepository.Put(new ExpenseRates()
                    //{
                    //    PkExpenseRatesId = dto.PkExpenseRatesId,
                    //    FkExpenseId = dto.FkExpenseId,
                    //    Rate = dto.Rate,
                    //    LastUpdatedOn = dto.date,
                    //    LastUpdatedById = dto.LastUpdatedById
                    //});
                    await _asyncRepository.PartialUpdate(dto, m => ///yahan woh values aengi jo ke update karni hongi 
                    {
                        //m.CustomerTypeId = dto.CustomerTypeId;
                        m.ExpenseId = dto.ExpenseId;
                        m.Rate = dto.Rate;
                    });
                    return new ResponseMessageDto()
                    {
                        Id = dto.Id,
                        SuccessMessage = ResponseMessages.UpdateSuccessMessage,
                        Success = true,
                        Error = false
                    };
                }
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    SuccessMessage = ResponseMessages.ExpenseAlreadyHaveOnThisDate,
                    Success = true,
                    Error = false
                };
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    FailureMessage = ResponseMessages.InsertionFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        

        public async Task<ResponseMessageDto> Delete(ExpenseRateRequestDto dto)
        {
            try
            {
                await _asyncRepository.DeleteAsync(_mapper.Map<DailyExpense>(dto));
                return new ResponseMessageDto()
                {
                    Id = dto.Id,
                    SuccessMessage = ResponseMessages.DeleteSuccessMessage,
                    Success = true,
                    Error = false
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    FailureMessage = ResponseMessages.InsertionFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        public async Task<IEnumerable<ExpenseRateResponseDto>> GetAll()
        {
            try
            {
                return await _expenseRateRepository.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<ExpenseRateResponseDto>> GetExpenseByExpenseIdAndDate(int expenseId, DateTime dateTime)
        {
            try
            {
                return await _expenseRateRepository.GetExpenseByExpenseIdAndDate(expenseId, dateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<ExpenseRateResponseDto>> GetExpenseByExpenseIdWithToAndFromDate(int expenseId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                return await _expenseRateRepository.GetExpenseByExpenseIdWithToAndFromDate(expenseId, fromDate, toDate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<ExpenseRateResponseDto>> GetAllExpenseByDate(DateTime date)
        {
            try
            {
                return await _expenseRateRepository.GetAllExpenseByDate(date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<ExpenseRateResponseDto>> GetAllByToAndFromDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return await _expenseRateRepository.GetAllByToAndFromDate(fromDate, toDate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
