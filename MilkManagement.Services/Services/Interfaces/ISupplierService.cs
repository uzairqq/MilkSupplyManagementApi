using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Services.Services.Interfaces
{
   public interface ISupplierService
    {
        Task<ResponseMessageDto> Post(AddSupplierRequestDto dto);
        Task<ResponseMessageDto> Put(AddSupplierRequestDto dto);
        Task<ResponseMessageDto> Delete(AddSupplierRequestDto dto);
        Task<IEnumerable<SupplierResponseDto>> GetAll();
        Task<SupplierResponseDto> GetById(int supplierId);
        Task<bool> IsSupplierNameAvailable(string name);
    }
}
