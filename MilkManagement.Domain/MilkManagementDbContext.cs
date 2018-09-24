using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Entities.Customer;

namespace MilkManagement.Domain
{
   public class MilkManagementDbContext:DbContext
    {
        public MilkManagementDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRates> CustomerRates { get; set; }
        public DbSet<CustomerSupplied> CustomerSupplied { get; set; }
    }
}
