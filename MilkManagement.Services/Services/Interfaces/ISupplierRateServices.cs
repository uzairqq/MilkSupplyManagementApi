using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Services.Services.Interfaces
{
   public interface ISupplierRateServices
    {
        Task<ResponseMessageDto> Post(SupplierRatesRequestDto dto);
        Task<ResponseMessageDto> Put(SupplierRatesRequestDto dto);
        Task<ResponseMessageDto> Delete(int id);
        Task<IEnumerable<GetSupplierRateResponseDto>> GetAll();
        Task<IEnumerable<GetSupplierRateResponseDto>> GetBySupplierRateId(int supplierRateId);
        Task<IEnumerable<GetSupplierRateResponseDto>> GetBySupplierId(int supplierId);
        Task<bool> IsRatesAssignedToSupplier(int supplierId);
        Task<GetCurrentRateBySupplierIdDto> GetCurrentRateBySupplierIdDropDown(int suppId);
    }
}
