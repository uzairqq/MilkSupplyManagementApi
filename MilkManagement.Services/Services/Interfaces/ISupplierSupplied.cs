using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Services.Services.Interfaces
{
   public interface ISupplierSuppliedServices
   {
       Task<IEnumerable<GetSuppliersForDrpDownDto>> Get();
   }
}
