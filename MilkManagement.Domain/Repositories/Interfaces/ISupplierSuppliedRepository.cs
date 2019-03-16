using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Domain.Repositories.Interfaces
{
    public interface ISupplierSuppliedRepository
    {
        Task<IEnumerable<GetSuppliersForDrpDownDto>> Get();
        Task<IEnumerable<SupplierSuppliedResponseDto>> Get(DateTime date);
        Task<bool> IsSupplierAvailableOnCurrentDate(int supplierId, DateTime date);
        Task<bool> IsSupplierAvailableOnCurrentDate(int supplierId, int supplierSuppliedId);
    }
}
