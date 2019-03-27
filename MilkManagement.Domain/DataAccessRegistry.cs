using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MilkManagement.Domain.Repositories.Implementation;
using MilkManagement.Domain.Repositories.Interfaces;

namespace MilkManagement.Domain
{
   public static class DataAccessRegistry
    {
        public static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            services.AddScoped(typeof(ICustomerRateRepository), typeof(CustomerRatesRepository));
            services.AddScoped(typeof(ICustomerSuppliedRepository), typeof(CustomerSuppliedRepository));
            services.AddScoped(typeof(IExpenseRepository), typeof(ExpenseRepository));
            services.AddScoped(typeof(ISupplierRepository), typeof(SupplierRepository));
            services.AddScoped(typeof(ISupplierRateRepository), typeof(SupplierRatesRepository));
            services.AddScoped(typeof(ISupplierSuppliedRepository), typeof(SupplierSuppliedRepository));
            services.AddScoped(typeof(IDailyExpenseRepository), typeof(DailyExpenseRepository));
            services.AddScoped(typeof(IMarketSupplierRepository), typeof(MarketSupplierRepository));
            services.AddScoped(typeof(IMarketPurchaseRepository), typeof(MarketPurchaseRepository));

        }
    }
}
