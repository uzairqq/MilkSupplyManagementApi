using MilkManagement.Domain.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Domain.Repositories.Interfaces
{
    public interface IMarketPurchaseRepository
    {
        Task<IEnumerable<MarketSupplierDropDownResponseDto>> GetMarketPurchasetDropDownValues(DateTime dateTime);
    }
}
