using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Repositories.Interfaces;

namespace MilkManagement.Domain.Repositories.Implementation
{
    public class SupplierRatesRepository : ISupplierRateRepository
    {
        private readonly MilkManagementDbContext _context;

        public SupplierRatesRepository(MilkManagementDbContext context)
        {
            _context = context;
        }
        public async Task<bool> IsRatesAssignedToSupplier(int supplierId)
        {
            try
            {
                return await Task.FromResult(_context.SupplierRates
                    .AsNoTracking()
                    .Any(i => i.SupplierId == supplierId && !i.IsDeleted));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> IsRatesAssignedToSupplier(int supplierRatesId, int supplierId)
        {
            try
            {
                return await Task.FromResult(_context.SupplierRates
                    .AsNoTracking()
                    .Any(i => i.SupplierId == supplierId && i.Id != supplierRatesId && !i.IsDeleted));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<GetCurrentRateBySupplierIdDto> GetCurrentRateBySupplierIdDropDown(int suppId)
        {
            try
            {
                return await Task.FromResult(_context.SupplierRates
                    .AsNoTracking()
                    .Where(i => i.SupplierId == suppId && !i.IsDeleted)
                    .Select(i => new GetCurrentRateBySupplierIdDto
                    {
                        CurrentRate = i.CurrentRate
                    }).SingleOrDefault());


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
