using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MilkManagement.CommonLibrary.Functions;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Supplier;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Services.Services.Implementation
{
    public class SupplierSuppliedServices : ISupplierSuppliedServices
    {

        private readonly ISupplierSuppliedRepository _supplierSuppliedRepository;
        private readonly ISupplierRateRepository _supplierRateRepository;
        private readonly IAsyncRepository<SupplierSupplied> _asyncRepository;
        private readonly IMapper _mapper;
        public SupplierSuppliedServices(ISupplierSuppliedRepository supplierSuppliedRepository, ISupplierRateRepository supplierRateRepository, IAsyncRepository<SupplierSupplied> asyncRepository, IMapper mapper)
        {
            _supplierSuppliedRepository = supplierSuppliedRepository;
            _supplierRateRepository = supplierRateRepository;
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetSuppliersForDrpDownDto>> GetDropDown(DateTime date)
        {
            try
            {
                var result = await _supplierSuppliedRepository.GetDropDown(date);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<IEnumerable<GetSuppliersForDrpDownDto>> GetDropDownForSearch()
        {
            try
            {
                var result = await _supplierSuppliedRepository.GetDropDownForSearch();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseMessageDto> Post(SupplierSuppliedRequestDto dto)
        {
            try
            {
                //if (await _supplierSuppliedRepository.IsSupplierAvailableOnCurrentDate(dto.SupplierId,
                //    dto.CreatedOn.Date))
                //    return new ResponseMessageDto()
                //    {
                //        Id = Convert.ToInt16(Enums.FailureId),
                //        FailureMessage = ResponseMessages.CustomerAlreadyInsertedInThisDate,
                //        Success = false,
                //        Error = true
                //    };
                var rate = _supplierRateRepository.GetCurrentRateBySupplierIdDropDown(dto.SupplierId);
                var supply =
                    SupplierSuppliedCalculationFunction.GetMorningSupplyAndAfterNoonSupply(dto.MorningPurchase,
                        dto.AfternoonPurchase, rate.Result);
                var sumUp = Convert.ToDouble(supply.morningPurchase) + Convert.ToDouble(supply.afternoonPurchase);
                dto.Rate = rate.Result;
                dto.Total = sumUp.ToString(CultureInfo.InvariantCulture);
                dto.MorningAmount = supply.morningPurchase;
                dto.AfternoonAmount = supply.afternoonPurchase;
                var customerSupplied = await _asyncRepository.AddAsync(new SupplierSupplied()
                {

                    SupplierId = dto.SupplierId,
                    MorningPurchase = dto.MorningPurchase,
                    AfternoonPurchase = dto.AfternoonPurchase,
                    MorningAmount = supply.morningPurchase,
                    AfternoonAmount = supply.afternoonPurchase,
                    Rate = rate.Result,
                    Total = Convert.ToString(sumUp, CultureInfo.InvariantCulture),
                    CreatedOn = dto.CreatedOn,
                    CreatedById = dto.CreatedById
                });
                return new ResponseMessageDto()
                {
                    Id = customerSupplied.Id,
                    SuccessMessage = ResponseMessages.InsertionSuccessMessage,
                    Success = true,
                    Error = false
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    FailureMessage = ResponseMessages.InsertionFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }
        public async Task<ResponseMessageDto> Put(SupplierSuppliedRequestDto dto)
        {
            try
            {
                //if (await _supplierSuppliedRepository.IsSupplierAvailableOnCurrentDate(dto.FkSupplierId,
                //    dto.PkSupplierSuppliedId))
                //    return new ReponseMessagesDto()
                //    {
                //        Success = false,
                //        FailureMessage = "You Have Already Inserted This Supplier On This Date",
                //        Error = true
                //    };
                var rate = _supplierRateRepository.GetCurrentRateBySupplierIdDropDown(dto.SupplierId);
                var supply =
                    SupplierSuppliedCalculationFunction.GetMorningSupplyAndAfterNoonSupply(dto.MorningPurchase,
                        dto.AfternoonPurchase, rate.Result);
                var sumUp = Convert.ToDouble(supply.morningPurchase) + Convert.ToDouble(supply.afternoonPurchase);
                dto.Rate = rate.Result;
                dto.Total = sumUp.ToString(CultureInfo.InvariantCulture);
                dto.MorningAmount = supply.morningPurchase;
                dto.AfternoonAmount = supply.afternoonPurchase;
                await _asyncRepository.PartialUpdate(dto, m => ///yahan woh values aengi jo ke update karni hongi 
                {
                    m.SupplierId = dto.SupplierId;
                    m.MorningPurchase = dto.MorningPurchase;
                    m.MorningAmount = dto.MorningAmount;
                    m.AfternoonPurchase = dto.AfternoonPurchase;
                    m.AfternoonAmount = dto.AfternoonAmount;
                    m.Rate = Convert.ToInt32(dto.Rate);
                    m.Total = dto.Total;
                });
                return new ResponseMessageDto()
                {
                    Id = dto.Id,
                    SuccessMessage = ResponseMessages.UpdateSuccessMessage,
                    Success = true,
                    Error = false
                };

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    FailureMessage = ResponseMessages.InsertionFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        public async Task<IEnumerable<SupplierSuppliedResponseDto>> GetGrid(DateTime date)
        {
            try
            {
               return await _supplierSuppliedRepository.GetGrid(date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseMessageDto> Delete(SupplierSuppliedRequestDto dto)
        {
            try
            {
                await _asyncRepository.DeleteAsync(_mapper.Map<SupplierSupplied>(dto));
                return new ResponseMessageDto()
                {
                    Id = dto.Id,
                    SuccessMessage = ResponseMessages.DeleteSuccessMessage,
                    Success = true,
                    Error = false
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    FailureMessage = ResponseMessages.InsertionFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }


        public async Task<IEnumerable<SupplierSuppliedResponseDto>> GetSuppliersDataToAndFromDate(int supplierId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                return await _supplierSuppliedRepository.GetSuppliersDataToAndFromDate(supplierId, fromDate, toDate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
