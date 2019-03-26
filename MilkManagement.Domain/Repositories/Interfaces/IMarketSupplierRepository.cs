using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Domain.Repositories.Interfaces
{
   public interface IMarketSupplierRepository
    {
        Task<bool> IsMarketSupplierNameAvailable(string name);
        Task<bool> IsMarketSupplierNameAvailable(int id, string name);
    }
}
