using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Customer;
using MilkManagement.Domain.Entities.Supplier;
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

        public async Task<IEnumerable<GetSupplierRatesDropdownDto>> GetAllSupplierForDropdown()
        {
            try
            {
                var result = await _context.Supplier
                    .AsNoTracking()
                    .Where(i=>!i.IsRateAssignedToSupplier && !i.IsDeleted)
                    .Select(i => new GetSupplierRatesDropdownDto()
                    {
                        SupplierId = i.Id,
                        SupplierName= i.SupplierName
                    }).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SetIsSupplierRateAssigned(int supplierId, bool isRateAssignedOrNot)
        {
            try
            {
                var model = new Supplier()
                {
                    Id = supplierId,
                    IsRateAssignedToSupplier = !isRateAssignedOrNot
                };
                _context.Supplier.Attach(model);
                model.IsRateAssignedToSupplier = isRateAssignedOrNot;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<GetSupplierRateResponseDto>> GetAll()
        {
            try
            {
                var result = await _context.SupplierRates
                    .AsNoTracking()
                    .Where(i => !i.IsDeleted)
                    .Select(i => new GetSupplierRateResponseDto
                    {
                        SupplierId = i.SupplierId,
                        SupplierName = i.Supplier.SupplierName,
                        CurrentRate = i.CurrentRate,
                        PreviousRate = i.PreviousRate,
                        CreatedOn = i.CreatedOn,
                        Id = i.Id
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
