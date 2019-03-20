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
       Task<IEnumerable<GetSuppliersForDrpDownDto>> GetDropDown(DateTime date);
       Task<ResponseMessageDto> Post(SupplierSuppliedRequestDto dto);
       Task<ResponseMessageDto> Put(SupplierSuppliedRequestDto dto);
       Task<IEnumerable<SupplierSuppliedResponseDto>> GetGrid(DateTime date);
       Task<ResponseMessageDto> Delete(SupplierSuppliedRequestDto dto);


   }
}
