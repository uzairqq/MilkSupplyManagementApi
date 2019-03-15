using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Services.Services.Implementation
{
   public class SupplierSuppliedServices:ISupplierSuppliedServices
   {

       private readonly ISupplierSuppliedRepository _supplierSuppliedRepository;
        public SupplierSuppliedServices(ISupplierSuppliedRepository supplierSuppliedRepository)
        {
            _supplierSuppliedRepository = supplierSuppliedRepository;
        }
        public async Task<IEnumerable<GetSuppliersForDrpDownDto>> Get()
        {
            try
            {
                var result = await _supplierSuppliedRepository.Get();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
