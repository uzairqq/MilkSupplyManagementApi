using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Services.Services.Interfaces
{
    public interface IMarketSellService
    {
        Task<ResponseMessageDto> Post(MarketSellRequestDto dto);
        Task<ResponseMessageDto> Put(MarketSellRequestDto dto);
        Task<ResponseMessageDto> Delete(MarketSellRequestDto dto);
        Task<IEnumerable<MarketSellResponseDto>> GetGridData(DateTime date);
    }
}
