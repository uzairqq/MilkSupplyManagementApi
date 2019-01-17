using System;
using System.Linq.Expressions;
using MilkManagement.Domain.Entities.Customer;

namespace MilkManagement.Domain.Specification
{
    public class CustomerWithType : BaseSpecification<Customer>
    {
        public CustomerWithType(int id): base(customer => customer.Id == id && customer.IsDeleted==false)
        {
            AddInclude($"{nameof(Customer.CustomerType)}.{nameof(CustomerType.Type)}");
        }

        public CustomerWithType() : base(customer=> customer.IsDeleted == false)
        {
            AddInclude($"{nameof(Customer.CustomerType)}.{nameof(CustomerType.Type)}");
        }
       
    }
}
