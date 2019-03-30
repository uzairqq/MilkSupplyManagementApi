using MilkManagement.Domain.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Domain.Repositories.Interfaces
{
    public interface IMarketSellRepository
    {
        Task<IEnumerable<MarketSellResponseDto>> GetGrid(DateTime date);
        Task<bool> IsMarketSupplierInsertedOnCurrentDate(int marketSupplierId);
        Task<bool> IsMarketSupplierInsertedOnCurrentDate(int marketSupplierId, int marketsellId);
    }
}
