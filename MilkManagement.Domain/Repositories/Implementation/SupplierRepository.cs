using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Repositories.Interfaces;

namespace MilkManagement.Domain.Repositories.Implementation
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly MilkManagementDbContext _dbContext;
        public SupplierRepository(MilkManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> IsSupplierNameAvailable(string name)
        {
            try
            {
                return await Task.FromResult(_dbContext.Supplier
                    .AsNoTracking()
                    .Any(i => i.SupplierName.Equals(name, StringComparison.OrdinalIgnoreCase) && !i.IsDeleted));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task<bool> IsSupplierNameAvailable(int supplierId, string supplierName)
        {
            try
            {
                return Task.FromResult(_dbContext.Supplier
                    .AsNoTracking().Any(i => i.Id != supplierId &&
                                             i.SupplierName.Equals(supplierName,
                                                 StringComparison.OrdinalIgnoreCase) && !i.IsDeleted));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
