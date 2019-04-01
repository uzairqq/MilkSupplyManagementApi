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
        Task<ResponseMessageDto> Put(MarketPurchaseRequestDto dto);
        Task<ResponseMessageDto> Delete(MarketPurchaseRequestDto dto);
        Task<IEnumerable<MarketPurchaseResponseDto>> GetMarketSupplierByParticularDate(int marketSupplierId,
            DateTime fromDate, DateTime toDate);
    }
}
