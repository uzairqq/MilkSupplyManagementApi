using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;

namespace MilkManagement.Domain.Repositories.Interfaces
{
   public interface ICustomerRepository
    {
        Task<bool> IsCustomerNameAvailable(string customerName);
        Task<bool> IsCustomerNameAvailable(int customerId,string customerName);
    }
}
