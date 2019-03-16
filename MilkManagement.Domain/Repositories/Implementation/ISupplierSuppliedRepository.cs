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
   public class SupplierSuppliedRepository:ISupplierSuppliedRepository
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
                var result =await _dbContext.SupplierRates
                    .AsNoTracking()
                    .Where(i=>!i.IsDeleted)
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
    }
}
