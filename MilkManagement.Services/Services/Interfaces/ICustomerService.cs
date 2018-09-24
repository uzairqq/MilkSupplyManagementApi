using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Services.Services.Interfaces
{
   public interface ICustomerService
    {
        Task<List<CustomerResponseDto>> GetAll();
        Task<ResponseMessageDto> AddCustomer(CustomerRequestDto dto);
        Task<CustomerResponseDto> GetCustomerById(int customerId);
        Task<ResponseMessageDto> DeleteCustomer(CustomerRequestDto dto);
        Task<ResponseMessageDto> UpdateCustomer(CustomerRequestDto dto);
        Task<ResponseMessageDto> IsCustomerNameAvailable(string customerName);
    }
}
