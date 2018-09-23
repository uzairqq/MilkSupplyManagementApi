using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Services;

namespace ApplicationCore.Interfaces.ServiceInterfaces
{
   public interface ICustomerService
   {
       Task<List<CustomerResponseViewModel>>  GetAllAsync();
   }
}
