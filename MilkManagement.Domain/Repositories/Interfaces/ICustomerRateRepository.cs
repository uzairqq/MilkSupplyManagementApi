using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Domain.Dto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Domain.Repositories.Interfaces
{
   public interface ICustomerRateRepository
    {
        Task<IEnumerable<GetCurrentRateByCustomerIdDto>> GetCustomerRatesByCustomerRatesId(int customerRatesId);
        int GetCurrentRateByCustomerId(int customerId);
        bool IsRateAssignedToCustomer(int customerId);
        bool IsRateAssignedToCustomer(  int customerId, int customerRatesId);
        //Task<GetCurrentRateByCustomerIdDto> GetCurrentRateByCustomerIdDropDown(int custId);
        Task<IEnumerable<GetCustomerRatesDropDownDto>> GetCustomerRatesDropDown(int typeId);
    }
}
