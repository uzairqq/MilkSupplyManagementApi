using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Expense;
using MilkManagement.Domain.Repositories.Interfaces;

namespace MilkManagement.Domain.Repositories.Implementation
{
    public class DailyExpenseRepository : EfRepository<DailyExpense>, IDailyExpenseRepository
    {
        private readonly MilkManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public DailyExpenseRepository(MilkManagementDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ExpenseRateResponseDto>> GetAll()
        {
            try
            {
                return await _dbContext.DailyExpense
                    .AsNoTracking()
                    .Where(i => !i.IsDeleted)
                    .Select(i => new ExpenseRateResponseDto()
                    {
                        Id = i.Id,
                        ExpenseName = i.Expense.ExpenseName,
                        ExpenseId = i.ExpenseId,
                        Rate = i.Rate,
                        CreatedOn = i.CreatedOn,
                        CreatedById = i.CreatedById,
                        LastUpdatedOn = i.LastUpdatedOn,
                        LastUpdatedById = i.LastUpdatedById
                    }).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<ExpenseRateResponseDto>> GetExpenseByExpenseIdAndDate(int expenseId, DateTime datetime)
        {
            try
            {
                return await _dbContext.DailyExpense
                    .AsNoTracking()
                    .Where(i => !i.IsDeleted)
                    .Select(i => new ExpenseRateResponseDto()
                    {
                        Id = i.Id,
                        ExpenseName = i.Expense.ExpenseName,
                        ExpenseId = i.ExpenseId,
                        Rate = i.Rate,
                        CreatedOn = i.CreatedOn,
                        CreatedById = i.CreatedById,
                        LastUpdatedOn = i.LastUpdatedOn,
                        LastUpdatedById = i.LastUpdatedById
                    }).ToListAsync();
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
                return await _dbContext.DailyExpense
                     .AsNoTracking()
                     .Where(i => i.ExpenseId == expenseId &&
                                 i.CreatedOn.Date >= fromDate &&
                                 i.CreatedOn.Date <= toDate)
                     .Select(i => new ExpenseRateResponseDto()
                     {
                         Id = i.Id,
                         ExpenseId = i.ExpenseId,
                         ExpenseName = i.Expense.ExpenseName,
                         Rate = i.Rate,
                         CreatedOn = i.CreatedOn,
                         CreatedById = i.CreatedById,
                         LastUpdatedById = i.LastUpdatedById,
                         LastUpdatedOn = i.LastUpdatedOn
                     }).ToListAsync();
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
                return await _dbContext.DailyExpense
                    .AsNoTracking()
                    .Where(i => i.CreatedOn.Date == date.Date && !i.IsDeleted)
                    .Select(i => new ExpenseRateResponseDto()
                    {
                        Id = i.Id,
                        ExpenseId = i.ExpenseId,
                        ExpenseName = i.Expense.ExpenseName,
                        Rate = i.Rate,
                        CreatedOn = i.CreatedOn,
                        CreatedById = i.CreatedById,
                        LastUpdatedById = i.LastUpdatedById,
                        LastUpdatedOn = i.LastUpdatedOn
                    }).ToListAsync();
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

                return await _dbContext.DailyExpense
                    .AsNoTracking()
                    .Where(i => i.CreatedOn.Date >= fromDate && i.CreatedOn.Date <= toDate)
                    .Select(i => new ExpenseRateResponseDto()
                    {
                        Id = i.Id,
                        ExpenseId = i.ExpenseId,
                        ExpenseName = i.Expense.ExpenseName,
                        Rate = i.Rate,
                        CreatedOn = i.CreatedOn,
                        CreatedById = i.CreatedById,
                        LastUpdatedById = i.LastUpdatedById,
                        LastUpdatedOn = i.LastUpdatedOn
                    }).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> IsExpenseInsertedOnCurrentDate(int expenseId, DateTime date)
        {
            try
            {
                var expense = _dbContext.DailyExpense
                    .AsNoTracking()
                    .Any(i => i.ExpenseId == expenseId && i.CreatedOn.Date == date.Date && !i.IsDeleted);
                return await Task.FromResult(expense);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> IsExpenseInsertedOnCurrentDate(int expenseId, int expenseRateId, DateTime date)
        {
            try
            {
                var expense = _dbContext.DailyExpense
                    .AsNoTracking()
                    .Any(i => i.ExpenseId == expenseId && i.Id != expenseRateId &&
                              i.CreatedOn.Date == date.Date && !i.IsDeleted);
                return await Task.FromResult(expense);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<DailyExpenseDropdownDto>> GetDrpDown(DateTime date)
        {
            return await _dbContext.Expense
                .AsNoTracking()
                .Where(i => !i.IsDeleted &&
                            !_dbContext.DailyExpense
                            .AsNoTracking()
                            .Where(o => o.CreatedOn.Date == date && !o.IsDeleted)
                            .Select(o => o.ExpenseId)
                            .Contains(i.Id)
                            )
                .Select(i => new DailyExpenseDropdownDto()
                {
                    ExpenseId = i.Id,
                    ExpenseName = i.ExpenseName
                }).ToListAsync();
        }

        public async Task<int> ListPost(IEnumerable<DailyExpense> dto)
        {
            try
            {
                _dbContext.DailyExpense.AddRange(dto);
               return await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
