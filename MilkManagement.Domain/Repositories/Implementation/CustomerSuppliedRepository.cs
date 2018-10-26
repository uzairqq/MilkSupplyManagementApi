﻿using System;
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
    }
}