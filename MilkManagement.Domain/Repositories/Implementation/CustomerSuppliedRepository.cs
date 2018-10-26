using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Customer;
using MilkManagement.Domain.Repositories.Interfaces;

namespace MilkManagement.Domain.Repositories.Implementation
{
   public class CustomerSuppliedRepository: EfRepository<CustomerSupplied>, ICustomerSuppliedRepository
    {
        private readonly MilkManagementDbContext _dbContext;

        public CustomerSuppliedRepository(MilkManagementDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }

        public bool IsCustomerRecordAvailableOnParticularDate(int customerId)
        {
            try
            {
                var record = _dbContext.CustomerSupplied
                    .AsNoTracking()
                    .Any(i => i.CreatedOn.Date == DateTime.Now.Date && i.CustomerId == customerId && !i.IsDeleted);
                return record;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool IsCustomerRecordAvailableOnParticularDate(int customerId, int customerSupplierId)
        {
            try
            {
                var record = _dbContext.CustomerSupplied
                    .AsNoTracking()
                    .Any(i => i.CreatedOn.Date == DateTime.Now.Date && i.CustomerId == customerId &&
                              i.Id != customerSupplierId && !i.IsDeleted);
                return record;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByDate(DateTime date)
        {
            try
            {
                var customerSupplied = _dbContext.CustomerSupplied
                    .AsNoTracking()
                    .Where(i => i.CreatedOn.Date == date.Date && !i.IsDeleted)
                    .Select(i => new CustomerSuppliedResponseDto()
                    {
                        CustomerType=i.Customer.CustomerType.Type,
                        CustomerTypeId=i.Customer.CustomerTypeId,
                        Id = i.Id,
                        CustomerId = i.CustomerId,
                        CustomerName = i.Customer.Name,
                        Rate = i.Rate,
                        MorningSupply = i.MorningSupply,
                        AfternoonSupply = i.AfternoonSupply,
                        MorningAmount = i.MorningAmount,
                        AfternoonAmount = i.AfternoonAmount,
                        Debit = i.Debit,
                        Credit = i.Credit,
                        Total = i.Total,
                        CreatedOn = i.CreatedOn.Date,
                        CreatedById = i.CreatedById,
                        LastUpdatedById = i.LastUpdatedById,
                        LastUpdatedOn = i.LastUpdatedOn
                    }).ToList();
                return await Task.FromResult(customerSupplied);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerId(int customerId)
        {
            try
            {
                var customerSupplied = _dbContext.CustomerSupplied
                    .AsNoTracking()
                    .Where(i => i.CustomerId == customerId && !i.IsDeleted)
                    .Select(i => new CustomerSuppliedResponseDto()
                    {
                        CustomerType=i.Customer.CustomerType.Type,
                        CustomerTypeId=i.Customer.CustomerTypeId,
                        Id = i.Id,
                        CustomerId = i.CustomerId,
                        CustomerName = i.Customer.Name,
                        Rate = i.Rate,
                        MorningSupply = i.MorningSupply,
                        AfternoonSupply = i.AfternoonSupply,
                        MorningAmount = i.MorningAmount,
                        AfternoonAmount = i.AfternoonAmount,
                        Debit = i.Debit,
                        Credit = i.Credit,
                        Total = i.Total,
                        CreatedOn = i.CreatedOn.Date,
                        CreatedById = i.CreatedById,
                        LastUpdatedById = i.LastUpdatedById,
                        LastUpdatedOn = i.LastUpdatedOn
                    })
                    .ToList();
                return await Task.FromResult(customerSupplied);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByStartAndEndDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                var customerSupplied = _dbContext.CustomerSupplied
                    .AsNoTracking()
                    .Where(i => i.CreatedOn.Date >= startDate.Date && i.CreatedOn.Date <= endDate.Date && !i.IsDeleted)
                    .Select(i => new CustomerSuppliedResponseDto()
                    {
                        CustomerType=i.Customer.CustomerType.Type,
                        CustomerTypeId=i.Customer.CustomerTypeId,
                        Id = i.Id,
                        CustomerId = i.CustomerId,
                        CustomerName = i.Customer.Name,
                        Rate = i.Rate,
                        MorningSupply = i.MorningSupply,
                        AfternoonSupply = i.AfternoonSupply,
                        MorningAmount = i.MorningAmount,
                        AfternoonAmount = i.AfternoonAmount,
                        Debit = i.Debit,
                        Credit = i.Credit,
                        Total = i.Total,
                        CreatedOn = i.CreatedOn.Date,
                        CreatedById = i.CreatedById,
                        LastUpdatedById = i.LastUpdatedById,
                        LastUpdatedOn = i.LastUpdatedOn
                    }).ToList();
                return await Task.FromResult(customerSupplied);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdAndParticularDate(int customerId, DateTime date)
        {
            try
            {
                var customerSupplied = _dbContext.CustomerSupplied
                    .AsNoTracking()
                    .Where(i => i.CustomerId == customerId && i.CreatedOn.Date == date.Date && !i.IsDeleted)
                    .Select(i => new CustomerSuppliedResponseDto()
                    {
                        CustomerType=i.Customer.CustomerType.Type,
                        CustomerTypeId=i.Customer.CustomerTypeId,
                        Id = i.Id,
                        CustomerId = i.CustomerId,
                        CustomerName = i.Customer.Name,
                        Rate = i.Rate,
                        MorningSupply = i.MorningSupply,
                        AfternoonSupply = i.AfternoonSupply,
                        MorningAmount = i.MorningAmount,
                        AfternoonAmount = i.AfternoonAmount,
                        Debit = i.Debit,
                        Credit = i.Credit,
                        Total = i.Total,
                        CreatedOn = i.CreatedOn.Date,
                        CreatedById = i.CreatedById,
                        LastUpdatedById = i.LastUpdatedById,
                        LastUpdatedOn = i.LastUpdatedOn
                    }).ToList();
                return await Task.FromResult(customerSupplied);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdStartDateAndEndDate(int customerId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var customerSupplied = _dbContext.CustomerSupplied
                    .AsNoTracking()
                    .Where(i => i.CustomerId == customerId && i.CreatedOn.Date >= startDate.Date &&
                                i.CreatedOn.Date <= endDate.Date && !i.IsDeleted)
                    .Select(i => new CustomerSuppliedResponseDto()
                    {
                        CustomerType=i.Customer.CustomerType.Type,
                        CustomerTypeId=i.Customer.CustomerTypeId,
                        Id = i.Id,
                        CustomerId = i.CustomerId,
                        CustomerName = i.Customer.Name,
                        Rate = i.Rate,
                        MorningSupply = i.MorningSupply,
                        AfternoonSupply = i.AfternoonSupply,
                        MorningAmount = i.MorningAmount,
                        AfternoonAmount = i.AfternoonAmount,
                        Debit = i.Debit,
                        Credit = i.Credit,
                        Total = i.Total,
                        CreatedOn = i.CreatedOn.Date,
                        CreatedById = i.CreatedById,
                        LastUpdatedById = i.LastUpdatedById,
                        LastUpdatedOn = i.LastUpdatedOn
                    }).ToList();
                return await Task.FromResult(customerSupplied);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}
