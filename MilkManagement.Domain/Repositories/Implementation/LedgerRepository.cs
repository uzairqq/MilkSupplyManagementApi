using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MilkManagement.Domain.Dto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Repositories.Interfaces;

namespace MilkManagement.Domain.Repositories.Implementation {
    public class LedgerRepository : ILedgerRepository {
        private readonly MilkManagementDbContext _dbContext;
        private readonly ILogger<LedgerRepository> _logger;

        public LedgerRepository (ILogger<LedgerRepository> logger, MilkManagementDbContext dbContext) {
            _logger = logger;
            _dbContext = dbContext;
        }
        public async Task<LedgerDto> Get (DateTime date) {
            try {
                var resultOfLedger = new LedgerDto () {
                    CustomerSupplied = await _dbContext.CustomerSupplied
                    .AsNoTracking ()
                    .Where (i => i.CreatedOn.Date == date)
                    .Select (i => new CustomerSuppliedResponseDto () {
                    MorningSupply = i.MorningSupply,
                    AfternoonSupply = i.AfternoonSupply,
                    MorningAmount = i.MorningAmount,
                    AfternoonAmount = i.AfternoonAmount
                    }).ToListAsync (),

                    SupplierSupplied = await _dbContext.SupplierSupplied
                    .AsNoTracking ()
                    .Where (i => i.CreatedOn.Date == date)
                    .Select (i => new SupplierSuppliedResponseDto () {
                    MorningPurchase = i.MorningPurchase,
                    AfternoonPurchase = i.AfternoonPurchase,
                    MorningAmount = i.MorningAmount,
                    AfternoonAmount = i.AfternoonAmount
                    }).ToListAsync (),

                    Expenses = await _dbContext.DailyExpense
                    .AsNoTracking ()
                    .Where (i => i.CreatedOn.Date == date)
                    .Select (i => new DailyExpenseDto { 
                    Rate = i.Rate
                    }).ToListAsync ()
                };
                return resultOfLedger;

            } catch (Exception ex) {
                _logger.LogError (ex.ToString ());
                throw;
            }
        }
    }
}