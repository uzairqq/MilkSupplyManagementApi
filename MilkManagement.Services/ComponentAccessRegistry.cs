﻿using System;
using Microsoft.Extensions.DependencyInjection;
using MilkManagement.Services.Services.Implementation;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Services
{
    public class ComponentAccessRegistry
    {

        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<ICustomerService, CustomerServices>();
            service.AddScoped<ICustomerRateService, CustomerRateService>();
            service.AddScoped<ICustomerSuppliedService, CustomerSuppliedServiceService>();
            service.AddScoped<IExpenseService, ExpenseService>();
            service.AddScoped<ISupplierService, SupplierService>();
            service.AddScoped<ISupplierRateServices, SupplierRatesServices>();
            service.AddScoped<ISupplierSuppliedServices, SupplierSuppliedServices>();
            service.AddScoped<IDailyExpenseService, DailyExpenseService>();
            service.AddScoped<IMarketSupplierService, MarketSupplierService>();
            service.AddScoped<IMarketPurchaseService, MarketPurchaseService>();
            service.AddScoped<IMarketSellService, MarketSellService>();
            service.AddScoped<ILedgerService, LedgerService>();
        }
    }
}
