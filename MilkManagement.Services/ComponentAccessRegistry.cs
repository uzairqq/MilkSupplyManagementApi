using System;
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
        }
    }
}
