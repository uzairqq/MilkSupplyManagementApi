using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Customer;

namespace MilkManagement.Domain.Repositories.Interfaces
{
   public interface ICustomerSuppliedRepository
    {
       bool IsCustomerRecordAvailableOnParticularDate(int customerId,DateTime date);
       bool IsCustomerRecordAvailableOnParticularDate(int customerId,int customerSupplierId,DateTime date);
        Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByDate(DateTime date,int typeId);
        //Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerId(int customerId);
        // Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByStartAndEndDate(DateTime startDate,
        //  DateTime endDate);
        // Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdAndParticularDate(int customerId, DateTime date);
        // Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdStartDateAndEndDate(
        //int customerId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<GeCustomerSuppliedtDropDownValuesDto>> GeCustomerSuppliedtDropDownValues(int typeId,DateTime dateTime);
        Task<int> ListPost(IEnumerable<CustomerSupplied> entity);
        Task<IEnumerable<GetFastEntryResponseDto>> GetFashEntryData(DateTime date);
    }
}
