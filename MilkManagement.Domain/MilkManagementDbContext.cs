﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Core.Validator;
using MilkManagement.Domain.Entities;
using MilkManagement.Domain.Entities.Customer;
using MilkManagement.Domain.Entities.Expense;
using MilkManagement.Domain.Entities.Market;
using MilkManagement.Domain.Entities.Supplier;

namespace MilkManagement.Domain
{
   public class MilkManagementDbContext:DbContext
    {
        public MilkManagementDbContext(DbContextOptions<MilkManagementDbContext> options):base(options)
        {
        }

        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRates> CustomerRates { get; set; }
        public DbSet<CustomerSupplied> CustomerSupplied { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierRate> SupplierRates { get; set; }
        public DbSet<SupplierSupplied> SupplierSupplied { get; set; }
        public DbSet<DailyExpense> DailyExpense{ get; set; }
        public DbSet<MarketSupplier> MarketSupplier { get; set; }
        public DbSet<MarketPurchase> MarketPurchase { get; set; }
        public DbSet<MarketSell> MarketSell { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CustomerType
            modelBuilder.Entity<CustomerType>().HasData(new CustomerType[] {
                new CustomerType { Id = 1, Type = "Daily",CreatedById=1,CreatedOn=DateTime.Now.Date, LastUpdatedById = 1, LastUpdatedOn = DateTime.Now.Date, IsDeleted =false,},
                new CustomerType { Id = 2, Type = "Weekly", CreatedById = 1, CreatedOn = DateTime.Now.Date, LastUpdatedById = 1, LastUpdatedOn = DateTime.Now.Date, IsDeleted = false, } });
            #endregion

        }



        public Task<int> SaveChangesAsync()
        {
            SoftDeleteEntitiesfunction();
            return base.SaveChangesAsync();
        }

        private void SoftDeleteEntitiesfunction()
        {
            try
            {
                foreach (var deletableEntity in ChangeTracker.Entries<ISoftDeletable>())
                {
                    if (deletableEntity.State == EntityState.Deleted)
                    {
                        //Deleted - set the deleted flag
                        deletableEntity.State = EntityState.Unchanged; //We need to set this to unchanged here, because setting it to modified seems to set ALL of its fields to modified
                        deletableEntity.Entity.IsDeleted = true; //This will set the entity's state to modified for the next time we query the ChangeTracker
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
