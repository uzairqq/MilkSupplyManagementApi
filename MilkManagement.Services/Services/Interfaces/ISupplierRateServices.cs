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
        Task<ResponseMessageDto> Delete(SupplierRatesRequestDto dto);
        Task<IEnumerable<GetSupplierRateResponseDto>> GetAll();
        Task<GetSupplierRateResponseDto> GetBySupplierRateId(int supplierRateId);
        Task<GetSupplierRateResponseDto> GetBySupplierId(int supplierId);
        Task<bool> IsRatesAssignedToSupplier(int supplierId);
        Task<GetCurrentRateBySupplierIdDto> GetCurrentRateBySupplierIdDropDown(int suppId);
        Task<IEnumerable<GetSupplierRatesDropdownDto>> GetDropDownSuppliers();
    }
}
