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
        Task<IEnumerable<MarketPurchaseResponseDto>> GetGrid(DateTime date);
        Task<bool> IsMarketSupplierInsertedOnCurrentDate(int marketSupplierId);
        Task<bool> IsMarketSupplierInsertedOnCurrentDate(int marketSupplierId, int marketSupplierSupplied);
        Task<IEnumerable<MarketPurchaseResponseDto>> GetMarketSupplierByParticularDate(int marketSupplierId, DateTime fromDate, DateTime toDate);
    }
}
