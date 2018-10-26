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
        Task<IEnumerable<CustomerSuppliedResponseDto>> Get();


    }
}
