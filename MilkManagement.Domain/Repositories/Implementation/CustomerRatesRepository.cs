using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Dto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Customer;
using MilkManagement.Domain.Repositories.Interfaces;

namespace MilkManagement.Domain.Repositories.Implementation
{
   public class CustomerRatesRepository: EfRepository<CustomerRates>, ICustomerRateRepository
    {
        private readonly MilkManagementDbContext _dbContext;

        public CustomerRatesRepository(MilkManagementDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GetCurrentRateByCustomerIdDto>> GetCustomerRatesByCustomerRatesId(int customerRatesId)
        {
            try
            {
                var customerRates = _dbContext.CustomerRates
                    .AsNoTracking()
                    .Where(i => i.Id == customerRatesId && !i.IsDeleted)
                    .Select(i => new GetCurrentRateByCustomerIdDto()
                    {
                        CurrentRate = i.CurrentRate,
                    }).ToList();
                return await Task.FromResult(customerRates);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int GetCurrentRateByCustomerId(int customerId)
        {
            try
            {
                var customerRates =  _dbContext.CustomerRates
                    .AsNoTracking()
                    .Where(i => i.CustomerId == customerId)
                    .Select(i => i.CurrentRate)
                    .SingleOrDefault();
                return  customerRates;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool IsRateAssignedToCustomer(int customerId)
        {
            try
            {
                var result= _dbContext.CustomerRates
                    .AsNoTracking()
                    .Any(o => o.CustomerId==customerId && !o.IsDeleted);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool IsRateAssignedToCustomer(int customerId, int customerRatesId)
        {
            try
            {
                return _dbContext.CustomerRates
                    .AsNoTracking()
                    .Any(i => i.CustomerId.Equals(customerId) && i.Id != customerRatesId && !i.IsDeleted);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<GetCustomerRatesDropDownDto>> GetCustomerRatesDropDown()
        {
            try
            {
                var result = await _dbContext.Customers
                    .AsNoTracking()
                    .Select(i => new GetCustomerRatesDropDownDto()
                    {
                        CustomerId = i.Id,
                        CustomerName = i.Name,
                        CustomerTypeId = i.CustomerTypeId,
                        Type = i.CustomerType.Type

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
