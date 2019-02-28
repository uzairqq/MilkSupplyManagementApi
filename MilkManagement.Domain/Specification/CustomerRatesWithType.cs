using System;
using System.Collections.Generic;
using System.Text;
using MilkManagement.Domain.Entities.Customer;

namespace MilkManagement.Domain.Specification
{
   public sealed class CustomerRatesWithType : BaseSpecification<CustomerRates>
    {
        //public CustomerRatesWithType(int id) : base(customer => customer.Id == id)
        //{
        //    AddInclude($"{nameof(CustomerRates.Customer.CustomerType)}.{nameof(CustomerType.Type)}");
        //}

        public CustomerRatesWithType() : base(customer => customer.IsDeleted == false)
        {
            //AddInclude(o => o.CustomerType);
            AddInclude($"{nameof(Customer.CustomerType)}.{nameof(CustomerType.Type)}");
        }
    }
}
