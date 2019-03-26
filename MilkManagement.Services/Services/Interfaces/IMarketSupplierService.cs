using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Services.Services.Interfaces
{
   public interface IMarketSupplierService
    {
        Task<ResponseMessageDto> Post(MarketSupplierRequestDto dto);
        Task<ResponseMessageDto> Put(MarketSupplierRequestDto dto);
        Task<ResponseMessageDto> Delete(MarketSupplierRequestDto dto);
        Task<IEnumerable<MarketSupplierResponseDto>> GetAll();
    }
}
