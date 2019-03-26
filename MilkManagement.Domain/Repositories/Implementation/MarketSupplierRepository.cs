using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Domain.Repositories.Implementation
{
    public class MarketSupplierRepository : IMarketSupplierRepository
    {
        private readonly MilkManagementDbContext _dbContext;
        public MarketSupplierRepository(MilkManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> IsMarketSupplierNameAvailable(string name)
        {
            try
            {
                return await _dbContext.MarketSupplier
                    .AsNoTracking()
                    .AnyAsync(i => i.MarketSupplierName.Equals(name, StringComparison.OrdinalIgnoreCase) && !i.IsDeleted);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<bool> IsMarketSupplierNameAvailable(int id, string name)
        {
            try
            {
                return await _dbContext.MarketSupplier
                                        .AsNoTracking()
                                        .AnyAsync(i => i.Id != id &&
                                             i.MarketSupplierName.Equals(name, StringComparison.OrdinalIgnoreCase) && !i.IsDeleted);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
