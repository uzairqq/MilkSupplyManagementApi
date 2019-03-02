using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Services.Services.Interfaces
{
   public interface ICustomerRateService
    {
        Task<ResponseMessageDto> AddCustomerRates(CustomerRatesRequestDto dto);
        Task<ResponseMessageDto> UpdateCustomerRates(CustomerRatesRequestDto dto);
        Task<IEnumerable<CustomerRatesResponseDto>> GetAllCustomerRates(int typeId);
        Task<CustomerRatesResponseDto> GetCustomerRatesById(int customerRatesId);
        Task <CustomerRatesResponseDto> GetCustomerRatesByCustomerId(int customerId);
        Task<ResponseMessageDto> DeleteCustomerRates(CustomerRatesRequestDto dto);
        bool IsRateAssignedToCustomer(int customerId);
        //Task<GetCurrentRateByCustomerIdDto> GetCurrentRateByCustomerIdDropDown(int custId);
        Task<IEnumerable<GetCustomerRatesDropDownDto>> GetCustomerRatesDropDown(int typeId);
    }
}
