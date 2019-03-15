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
    }
}
