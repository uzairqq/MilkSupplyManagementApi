using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;

namespace MilkManagement.Domain.Repositories.Interfaces
{
   public interface ICustomerSuppliedRepository
    {
       bool IsCustomerRecordAvailableOnParticularDate(int customerId);
       bool IsCustomerRecordAvailableOnParticularDate(int customerId,int customerSupplierId);
    }
}
