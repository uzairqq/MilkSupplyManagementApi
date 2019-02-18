using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Entities.Expense;
using MilkManagement.Domain.Repositories.Interfaces;

namespace MilkManagement.Domain.Repositories.Implementation
{
   public class ExpenseRepository:EfRepository<Expense>, IExpenseRepository
    {
        private readonly MilkManagementDbContext _dbContext;

        public ExpenseRepository(MilkManagementDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> IsExpenseNameAvailable(string expenseName)
        {
            try
            {
                return await Task.FromResult(_dbContext.Expense
                    .AsNoTracking()
                    .Any(i => i.ExpenseName.Equals(expenseName, StringComparison.OrdinalIgnoreCase) && !i.IsDeleted));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<bool> IsExpenseNameAvailable(int expenseId, string expenseName)
        {
            try
            {
                var result= Task.FromResult(_dbContext.Expense
                    .AsNoTracking()
                    .Any(i => i.Id != expenseId &&
                              i.ExpenseName==expenseName && !i.IsDeleted));
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

       
    }
}
