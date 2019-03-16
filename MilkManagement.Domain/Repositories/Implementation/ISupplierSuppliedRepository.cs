using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Repositories.Interfaces;

namespace MilkManagement.Domain.Repositories.Implementation
{
    public class SupplierSuppliedRepository : ISupplierSuppliedRepository
    {
        private readonly MilkManagementDbContext _dbContext;
        public SupplierSuppliedRepository(MilkManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<GetSuppliersForDrpDownDto>> Get()
        {
            try
            {
                var result = await _dbContext.SupplierRates
                    .AsNoTracking()
                    .Where(i => !i.IsDeleted)
                    .Select(i => new GetSuppliersForDrpDownDto()
                    {
                        SupplierId = i.SupplierId,
                        SupplierName = i.Supplier.SupplierName
                    }).ToListAsync();
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<bool> IsSupplierAvailableOnCurrentDate(int supplierId, DateTime date)
        {
            try
            {
                var addDays = date.AddDays(1);
                var convertedDate = addDays.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                var supplier = _dbContext.SupplierSupplied
                    .AsNoTracking()
                    .Any(i => i.SupplierId == supplierId && i.CreatedOn.Date == Convert.ToDateTime(convertedDate) && !i.IsDeleted);
                return await Task.FromResult(supplier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> IsSupplierAvailableOnCurrentDate(int supplierId, int supplierSuppliedId)
        {
            try
            {
                var supplier = _dbContext.SupplierSupplied
                    .AsNoTracking()
                    .Any(i => i.SupplierId == supplierId && i.Id != supplierSuppliedId &&
                              i.CreatedOn.Date == DateTime.Now.AddDays(1) && !i.IsDeleted);
                return await Task.FromResult(supplier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<IEnumerable<SupplierSuppliedResponseDto>> Get(DateTime date)
        {
            try
            {
                var result = await _dbContext.SupplierSupplied
                    .AsNoTracking()
                    .Where(i => i.CreatedOn.Date == date.Date && !i.IsDeleted)
                    .Select(i => new SupplierSuppliedResponseDto()
                    {
                        Id = i.Id,
                        SupplierId = i.SupplierId,
                        SupplierName = i.Supplier.SupplierName,
                        MorningPurchase = i.MorningPurchase,
                        AfternoonPurchase = i.AfternoonPurchase,
                        MorningAmount = i.MorningAmount,
                        AfternoonAmount = i.AfternoonAmount,
                        Rate = i.Rate,
                        Total = i.Total,
                        CreatedOn = i.CreatedOn,
                        CreatedById = i.CreatedById,
                        LastUpdatedOn = i.LastUpdatedOn,
                        LastUpdatedById = i.LastUpdatedById,
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
