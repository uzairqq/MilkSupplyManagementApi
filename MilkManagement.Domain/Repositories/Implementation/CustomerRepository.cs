using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Constants;
using MilkManagement.Domain.Entities.Customer;
using MilkManagement.Domain.Repositories.Interfaces;

namespace MilkManagement.Domain.Repositories.Implementation
{
   public class CustomerRepository: EfRepository<Customer>, ICustomerRepository
    {
        private readonly MilkManagementDbContext _dbContext;

        public CustomerRepository(MilkManagementDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbContext = dbContext;
        }

        public bool IsCustomerNameAvailable(string customerName)
        {
            try
            {
                return _dbContext.Customers
                    .AsNoTracking()
                    .Any(i => i.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase) && !i.IsDeleted);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public  bool IsCustomerNameAvailable(int customerId, string customerName)
        {
            try
            {
                return _dbContext.Customers.AsNoTracking().Any(i => i.Id != customerId &&
                                                                                 i.Name.Equals(customerName,
                                                                                     StringComparison.OrdinalIgnoreCase) && !i.IsDeleted);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void  SetIsCustomerRateAssigned(int customerId)
        {
            try
            {
                var model = new Customer()
                {
                    Id = customerId
                };
                 _dbContext.Customers.Attach(model);
                model.IsRateAssignedToCustomer = true;
               _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
