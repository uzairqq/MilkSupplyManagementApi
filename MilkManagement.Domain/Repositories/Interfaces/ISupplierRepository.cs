using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Domain.Repositories.Interfaces
{
   public interface ISupplierRepository
    {
        Task<bool> IsSupplierNameAvailable(string name);
        Task<bool> IsSupplierNameAvailable(int supplierId, string supplierName);
    }
}
