using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Services.Services.Interfaces
{
   public interface ISupplierSuppliedServices
   {
       Task<IEnumerable<GetSuppliersForDrpDownDto>> Get();
       Task<ResponseMessageDto> Post(SupplierSuppliedRequestDto dto);

   }
}
