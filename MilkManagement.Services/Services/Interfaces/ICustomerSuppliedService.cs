using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;

namespace MilkManagement.Services.Services.Interfaces
{
   public interface ICustomerSuppliedService
   {
        Task<ResponseMessageDto> Post(CustomerSuppliedRequestDto dto);
    }
}
