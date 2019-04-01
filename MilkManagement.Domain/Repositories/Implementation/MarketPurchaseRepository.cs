using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Domain.Repositories.Implementation
{
    public class MarketPurchaseRepository : IMarketPurchaseRepository
    {
        private readonly MilkManagementDbContext _dbContext;

        public MarketPurchaseRepository(MilkManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MarketPurchaseResponseDto>> GetGrid(DateTime date)
        {
            try
            {
                var result = await _dbContext.MarketPurchase
                    .AsNoTracking()
                    .Where(i => i.CreatedOn.Date == date && !i.IsDeleted)
                    .Select(i => new MarketPurchaseResponseDto()
                    {
                        Id = i.Id,
                        MarketSupplierId = i.MarketSupplierId,
                        MarketSupplierName = i.MarketSupplier.MarketSupplierName,
                        MorningPurchase = i.MorningPurchase,
                        MorningRate = i.MorningRate,
                        MorningAmount = i.MorningAmount,
                        AfternoonPurchase = i.AfternoonPurchase,
                        AfternoonAmount = i.AfternoonAmount,
                        AfternoonRate = i.AfternoonRate,
                        TotalMilk = i.TotalMilk,
                        TotalAmount = i.TotalAmount
                    }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
        public async Task<bool> IsMarketSupplierInsertedOnCurrentDate(int marketSupplierId)
        {
            try
            {

                var market = await _dbContext.MarketPurchase
                    .AsNoTracking()
                    .AnyAsync(i => i.MarketSupplierId == marketSupplierId && i.CreatedOn.Date == DateTime.Now.Date &&
                              !i.IsDeleted);
                return market;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> IsMarketSupplierInsertedOnCurrentDate(int marketSupplierId, int marketSupplierSupplied)
        {
            try
            {
                var market = await _dbContext.MarketPurchase
                    .AsNoTracking()
                    .AnyAsync(i => i.MarketSupplierId == marketSupplierId &&
                              i.Id != marketSupplierSupplied &&
                              i.CreatedOn.Date == DateTime.Now.Date && !i.IsDeleted);
                return market;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<IEnumerable<MarketPurchaseResponseDto>> GetMarketSupplierByParticularDate(int marketSupplierId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var result= await _dbContext.MarketPurchase
                    .AsNoTracking()
                    .Where(i => i.MarketSupplierId == marketSupplierId && i.CreatedOn.Date >= fromDate.Date && i.CreatedOn.Date <= toDate.Date && !i.IsDeleted)
                    .Select(i => new MarketPurchaseResponseDto()
                    {
                        Id = i.Id,
                        Date = i.CreatedOn.ToString("dd/MM/yyyy"),
                        MarketSupplierId = i.MarketSupplierId,
                        MarketSupplierName = i.MarketSupplier.MarketSupplierName,
                        MorningPurchase = i.MorningPurchase,
                        MorningRate=i.MorningRate,
                        AfternoonRate=i.AfternoonRate,
                        AfternoonPurchase = i.AfternoonPurchase,
                        MorningAmount = i.MorningAmount,
                        AfternoonAmount = i.AfternoonAmount,
                        TotalAmount=i.TotalAmount,
                        TotalMilk=i.TotalMilk
                    }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<MarketSupplierDropDownResponseDto>> GetMarketPurchasetDropDownValues(DateTime dateTime)
        {
            try
            {
                var result = await _dbContext.MarketSupplier
                    .AsNoTracking()
                    .Where(i => !i.IsDeleted)
                    .Select(i => new MarketSupplierDropDownResponseDto()
                    {
                        MarketSupplierId = i.Id,
                        MarketSupplierName = i.MarketSupplierName
                    }).ToListAsync();
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
