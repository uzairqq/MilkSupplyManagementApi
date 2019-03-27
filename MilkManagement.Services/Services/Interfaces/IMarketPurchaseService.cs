using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Services.Services.Interfaces
{
   public interface IMarketPurchaseService
    {
        Task<ResponseMessageDto> Post(MarketPurchaseRequestDto dto);
        Task<IEnumerable<MarketSupplierDropDownResponseDto>> GeCustomerSuppliedtDropDownValues(DateTime date);
        Task<IEnumerable<MarketPurchaseResponseDto>> GetGrid(DateTime date);
    }
}
