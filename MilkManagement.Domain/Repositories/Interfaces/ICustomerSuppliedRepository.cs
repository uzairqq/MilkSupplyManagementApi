using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Domain.Repositories.Interfaces
{
   public interface ICustomerSuppliedRepository
    {
       bool IsCustomerRecordAvailableOnParticularDate(int customerId);
       bool IsCustomerRecordAvailableOnParticularDate(int customerId,int customerSupplierId);
       Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByDate(DateTime date);
       Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerId(int customerId);
        Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByStartAndEndDate(DateTime startDate,
         DateTime endDate);
        Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdAndParticularDate(int customerId, DateTime date);
        Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdStartDateAndEndDate(
       int customerId, DateTime startDate, DateTime endDate);
    }
}
