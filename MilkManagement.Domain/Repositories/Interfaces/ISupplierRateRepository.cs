using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Domain.Repositories.Interfaces
{
    public interface ISupplierRateRepository
    {
        Task<bool> IsRatesAssignedToSupplier(int supplierId);
        Task<bool> IsRatesAssignedToSupplier(int supplierRatesId, int supplierId);
        Task<int> GetCurrentRateBySupplierIdDropDown(int suppId);
        Task<IEnumerable<GetSupplierRatesDropdownDto>> GetAllSupplierForDropdown();
        Task<IEnumerable<GetSupplierRatesDropdownDto>> GetDropDownSuppliersAllWithOutRateAssigned();
        void SetIsSupplierRateAssigned(int supplierId, bool isRateAssignedOrNot);
        Task<IEnumerable<GetSupplierRateResponseDto>> GetAll();


    }
}
