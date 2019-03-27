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
        public async Task<IEnumerable<MarketSupplierDropDownResponseDto>> GetMarketPurchasetDropDownValues(DateTime dateTime)
        {
            try
            {
                var result = await _dbContext.MarketSupplier
                    .AsNoTracking()
                    .Where(i=>!i.IsDeleted)
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
