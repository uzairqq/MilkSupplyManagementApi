using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Domain.Repositories.Interfaces
{
    public interface ISupplierSuppliedRepository
    {
        Task<IEnumerable<GetSuppliersForDrpDownDto>> GetDropDown(DateTime date);
        Task<IEnumerable<SupplierSuppliedResponseDto>> GetGrid(DateTime date);
        Task<bool> IsSupplierAvailableOnCurrentDate(int supplierId, DateTime date);
        Task<bool> IsSupplierAvailableOnCurrentDate(int supplierId, int supplierSuppliedId);
    }
}
