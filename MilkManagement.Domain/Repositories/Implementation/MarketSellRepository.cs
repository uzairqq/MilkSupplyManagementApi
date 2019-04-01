using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Market;
using MilkManagement.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Domain.Repositories.Implementation
{
   public class MarketSellRepository : EfRepository<MarketSell>, IMarketSellRepository
    {
        private readonly MilkManagementDbContext _dbContext;

        public MarketSellRepository(MilkManagementDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MarketSellResponseDto>> GetGrid(DateTime date)
        {
            try
            {
                var result = await _dbContext.MarketSell
                    .AsNoTracking()
                    .Where(i => i.CreatedOn.Date == date && !i.IsDeleted)
                    .Select(i => new MarketSellResponseDto()
                    {
                        Id = i.Id,
                        MarketSupplierId = i.MarketSupplierId,
                        MarketSupplierName = i.MarketSupplier.MarketSupplierName,
                        MorningSell = i.MorningSell,
                        MorningRate = i.MorningRate,
                        MorningAmount = i.MorningAmount,
                        AfternoonSell = i.AfternoonSell,
                        AfternoonAmount = i.AfternoonAmount,
                        AfternoonRate = i.AfternoonRate,
                        TotalMilk = i.TotalMilk,
                        TotalAmount = i.Total,
                        ComissionRate=i.ComissionRate,
                        TotalComission=i.TotalComission
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

                var market = await _dbContext.MarketSell
                    .AsNoTracking()
                    .AnyAsync(i => i.MarketSupplierId == marketSupplierId && i.CreatedOn.Date == DateTime.Now.Date &&
                              !i.IsDeleted);
                return  market;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> IsMarketSupplierInsertedOnCurrentDate(int marketSupplierId, int marketSellId)
        {
            try
            {
                var market = await _dbContext.MarketSell
                    .AsNoTracking()
                    .AnyAsync(i => i.MarketSupplierId == marketSupplierId &&
                              i.Id != marketSellId &&
                              i.CreatedOn.Date == DateTime.Now.Date && !i.IsDeleted);
                return  market;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<IEnumerable<MarketSellResponseDto>> GetMarketSupplierByParticularDate(int marketSupplierId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var result= await _dbContext.MarketSell
                    .AsNoTracking()
                    .Where(i => i.MarketSupplierId == marketSupplierId && i.CreatedOn.Date >= fromDate.Date && i.CreatedOn.Date <= toDate.Date && !i.IsDeleted)
                    .Select(i => new MarketSellResponseDto()
                    {

                        Id = i.Id,
                        Date = i.CreatedOn.ToString("dd/MM/yyyy"),
                        MarketSupplierId = i.MarketSupplierId,
                        MarketSupplierName = i.MarketSupplier.MarketSupplierName,
                        MorningSell = i.MorningSell,
                        AfternoonSell = i.AfternoonSell,
                        MorningRate=i.MorningRate,
                        AfternoonRate=i.AfternoonRate,
                        MorningAmount = i.MorningAmount,
                        AfternoonAmount = i.AfternoonAmount,
                        TotalAmount = i.Total,
                        TotalComission=i.TotalComission,
                        TotalMilk=i.TotalMilk,
                        ComissionRate=i.ComissionRate
                        
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
