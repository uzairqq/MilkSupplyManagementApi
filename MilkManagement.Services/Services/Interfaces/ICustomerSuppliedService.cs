using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Services.Services.Interfaces
{
   public interface ICustomerSuppliedService
   {
        Task<ResponseMessageDto> Post(CustomerSuppliedRequestDto dto);
        Task<ResponseMessageDto> Put(CustomerSuppliedRequestDto dto);
        //Task<IEnumerable<CustomerSuppliedResponseDto>> Get();
        Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByDate(DateTime date);
        //Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerId(int customerId);
        //Task<CustomerSuppliedResponseDto> GetCustomerSuppliedByCustomerSuppliedId(int customerSuppliedId);

        //Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByStartAndEndDate(DateTime startDate,
        //  DateTime endDate);
        //Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdAndParticularDate(int customerId, DateTime date);
        //Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdStartDateAndEndDate(
        //    int customerId, DateTime startDate, DateTime endDate);
        Task<ResponseMessageDto> Delete(CustomerSuppliedRequestDto dto);
        Task<IEnumerable<GeCustomerSuppliedtDropDownValuesDto>> GeCustomerSuppliedtDropDownValues(int typeId,DateTime dateTime);
   }
}
