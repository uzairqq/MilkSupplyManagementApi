//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using MilkManagement.Constants;
//using MilkManagement.Domain.Dto.RequestDto;
//using MilkManagement.Domain.Dto.ResponseDto;
//using MilkManagement.Domain.Entities.Customer;
//using MilkManagement.Domain.Repositories.Interfaces;

//namespace MilkManagement.Services.Services.Implementation
//{
//    public class SupplierRatesServices
//    {
//        private readonly IAsyncRepository<SupplierRate> _asyncRepository;
//        public SupplierRatesServices(IAsyncRepository<SupplierRates>)
//        {

//        }
//        public async Task<ResponseMessageDto> Post(SupplierRatesRequestDto dto)
//        {
//            try
//            {
//                if (!await _supplierRateRepository.IsRatesAssignedToSupplier(dto.SupplierId))
//                {
//                    var supp = await _.Post(new SupplierRates()
//                    {
//                        FkSupplierId = dto.FkSupplierId,
//                        CurrentRate = dto.CurrentRate,
//                        PreviousRate = dto.PreviousRate,
//                        CreatedOn = DateTime.Now,
//                        CreatedById = dto.CreatedById
//                    });
//                    return new ResponseMessageDto()
//                    {
//                        Id = supp,
//                        Success = true,
//                        SuccessMessage = "Data Successfully Inserted",
//                        Error = false
//                    };
//                }
//                return new ReponseMessagesDto()
//                {

//                    Success = false,
//                    FailureMessage = "Rates Already Assigned To This Suppliers",
//                    Error = true
//                };
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                return new ResponseMessageDto()
//                {

//                    Success = false,
//                    FailureMessage = "Data Not Inserted",
//                    Error = true
//                };
//            }
//        }

//        public async Task<ResponseMessageDto> Put(UpdateSupplierRateRequestDto dto)
//        {
//            try
//            {
//                if (!await _supplierRateRepository.IsRatesAssignedToSupplier(dto.PkSupplierRatesId, dto.FkSupplierId))
//                {
//                    var supp = await _supplierRateRepository.Put(new SupplierRates()
//                    {
//                        PkSupplierRatesId = dto.PkSupplierRatesId,
//                        FkSupplierId = dto.FkSupplierId,
//                        CurrentRate = dto.CurrentRate,
//                        PreviousRate = dto.PreviousRate,
//                        LastUpdatedOn = DateTime.Now,
//                        LastUpdatedById = dto.LastUpdatedById
//                    });
//                    return new ReponseMessagesDto()
//                    {
//                        Id = supp,
//                        Success = true,
//                        SuccessMessage = "Data Successfully Updated",
//                        Error = false
//                    };
//                }
//                return new ReponseMessagesDto()
//                {
//                    Success = false,
//                    FailureMessage = "Rates Already Assigned To This Suppliers",
//                    Error = true
//                };
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                return new ReponseMessagesDto()
//                {

//                    Success = false,
//                    FailureMessage = "Data Not Updated",
//                    Error = true
//                };
//            }
//        }

//        public async Task<ResponseMessageDto> Delete(int id)
//        {
//            try
//            {
//                var supp = await _supplierRateRepository.Delete(id);
//                return new ReponseMessagesDto()
//                {
//                    Id = supp,
//                    Success = true,
//                    SuccessMessage = "Data Successfully Deleted",
//                    Error = false
//                };
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                return new ReponseMessagesDto()
//                {
//                    Success = false,
//                    FailureMessage = "Data Not Deleted",
//                    Error = true
//                };
//            }
//        }

//        public async Task<IEnumerable<GetSupplierRateResponseDto>> GetAll()
//        {
//            try
//            {
//                return await _supplierRateRepository.GetAll();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }

//        public async Task<IEnumerable<GetSupplierRateResponseDto>> GetBySupplierRateId(int supplierRateId)
//        {
//            try
//            {
//                return await _supplierRateRepository.GetBySupplierRateId(supplierRateId);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }

//        public async Task<IEnumerable<GetSupplierRateResponseDto>> GetBySupplierId(int supplierId)
//        {
//            try
//            {
//                return await _supplierRateRepository.GetBySupplierId(supplierId);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }

//        public async Task<bool> IsRatesAssignedToSupplier(int supplierId)
//        {
//            try
//            {
//                return await _supplierRateRepository.IsRatesAssignedToSupplier(supplierId);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }

//        public async Task<GetCurrentRateBySupplierIdDto> GetCurrentRateBySupplierIdDropDown(int suppId)
//        {
//            try
//            {
//                return await _supplierRateRepository.GetCurrentRateBySupplierIdDropDown(suppId);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//    }
//}
