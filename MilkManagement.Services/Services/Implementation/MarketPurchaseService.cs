using AutoMapper;
using MilkManagement.CommonLibrary.Functions;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Market;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilkManagement.Services.Services.Implementation
{
    public class MarketPurchaseService : IMarketPurchaseService
    {
        private readonly IAsyncRepository<MarketPurchase> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly IMarketPurchaseRepository _marketPurchaseRepository;
        public MarketPurchaseService(
            IAsyncRepository<MarketPurchase> asyncRepository,
            IMapper mapper,
            IMarketPurchaseRepository marketPurchaseRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _marketPurchaseRepository = marketPurchaseRepository;
        }

        public async Task<ResponseMessageDto> Delete(MarketPurchaseRequestDto dto)
        {
            try
            {
                await _asyncRepository.DeleteAsync(_mapper.Map<MarketPurchase>(dto));
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
                    FailureMessage = ResponseMessages.DeleteFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        public async Task<IEnumerable<MarketSupplierDropDownResponseDto>> GeCustomerSuppliedtDropDownValues(DateTime date)
        {
            try
            {
                var result = await _marketPurchaseRepository.GetMarketPurchasetDropDownValues(date);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public async Task<IEnumerable<MarketPurchaseResponseDto>> GetGrid(DateTime date)
        {
            try
            {
                var result = await _marketPurchaseRepository.GetGrid(date);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public async Task<ResponseMessageDto> Post(MarketPurchaseRequestDto dto)
        {
            try
            {
                //if (!await _supplierSuppliedRepository.IsMarketSupplierInsertedOnCurrentDate(dto.MarketSupplierId))
                //{

                var (morningsupply, afternoonSupply) =
                    MarketPurchaseCalculation.GetMorningSupplyAndAfterNoonSupply(dto.MorningPurchase,
                        dto.AfternoonPurchase, Convert.ToInt32(dto.MorningRate), Convert.ToInt32(dto.AfternoonRate));
                var sumUp = Convert.ToDouble(morningsupply) +
                            Convert.ToDouble(afternoonSupply);
                string grandMilkTotal = TotalMilkCalculate.TotalMilkCalulate(dto.MorningPurchase, dto.AfternoonPurchase);
                dto.MorningAmount = morningsupply;
                dto.AfternoonAmount = afternoonSupply;
                dto.TotalAmount = Convert.ToInt32(sumUp);
                dto.TotalMilk = grandMilkTotal;
                var marketPucrchase = await _asyncRepository.AddAsync(_mapper.Map<MarketPurchase>(dto));

                return new ResponseMessageDto()
                {
                    Id = marketPucrchase.Id,
                    SuccessMessage = ResponseMessages.InsertionSuccessMessage,
                    Success = true,
                    Error = false
                };
                //}
                //return new ReponseMessagesDto()
                //{
                //    Success = false,
                //    FailureMessage = "You Have Already Added This Market Supplier In This Date",
                //    Error = true
                //};

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

        public async Task<ResponseMessageDto> Put(MarketPurchaseRequestDto dto)
        {
            try
            {
                var (morningsupply, afternoonSupply) =
                   MarketPurchaseCalculation.GetMorningSupplyAndAfterNoonSupply(dto.MorningPurchase,
                       dto.AfternoonPurchase, Convert.ToInt32(dto.MorningRate), Convert.ToInt32(dto.AfternoonRate));
                var sumUp = Convert.ToDouble(morningsupply) +
                            Convert.ToDouble(afternoonSupply);
                string grandMilkTotal = TotalMilkCalculate.TotalMilkCalulate(dto.MorningPurchase, dto.AfternoonPurchase);
                dto.MorningAmount = morningsupply;
                dto.AfternoonAmount = afternoonSupply;
                dto.TotalAmount = Convert.ToInt32(sumUp);
                dto.TotalMilk = grandMilkTotal;
                await _asyncRepository.PartialUpdate(dto, m => ///yahan woh values aengi jo ke update karni hongi 
                {
                    m.MarketSupplierId = dto.MarketSupplierId;
                    m.MorningPurchase = dto.MorningPurchase;
                    m.MorningRate = dto.MorningRate;
                    m.MorningAmount = dto.MorningAmount;
                    m.AfternoonPurchase = dto.AfternoonPurchase;
                    m.AfternoonAmount = dto.AfternoonAmount;
                    m.AfternoonRate = dto.AfternoonRate;
                    m.TotalAmount = dto.TotalAmount;
                    m.TotalMilk = dto.TotalMilk;
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
                    FailureMessage = ResponseMessages.UpdateFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }
    }
}
