using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;

namespace MilkManagement.Domain.Repositories.Interfaces
{
   public interface ICustomerRepository
    {
        bool IsCustomerNameAvailable(string customerName);
        bool IsCustomerNameAvailable(int customerId,string customerName);
        void SetIsCustomerRateAssigned(int customerId,bool isRateAssignedOrNot);
    }
}
