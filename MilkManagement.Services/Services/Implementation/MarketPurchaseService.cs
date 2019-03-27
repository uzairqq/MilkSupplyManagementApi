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
        public MarketPurchaseService(IAsyncRepository<MarketPurchase> asyncRepository, IMapper mapper, IMarketPurchaseRepository marketPurchaseRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _marketPurchaseRepository = marketPurchaseRepository;
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

        public async Task<ResponseMessageDto> Post(MarketPurchaseRequestDto dto)
        {
            try
            {
                //if (!await _supplierSuppliedRepository.IsMarketSupplierInsertedOnCurrentDate(dto.MarketSupplierId))
                //{

                var supply =
                    MarketPurchaseCalculation.GetMorningSupplyAndAfterNoonSupply(dto.MorningPurchase,
                        dto.AfternoonPurchase, Convert.ToInt32(dto.MorningRate), Convert.ToInt32(dto.AfternoonRate));
                var sumUp = Convert.ToDouble(supply.morningsupply) +
                            Convert.ToDouble(supply.afternoonSupply);
                //int addAllComissionValues = SupplierComissionCalulate(dto);
                string grandMilkTotal = TotalMilkCalculate.TotalMilkCalulate(dto.MorningPurchase, dto.AfternoonPurchase);
                dto.MorningAmount = supply.morningsupply;
                dto.AfternoonAmount = supply.afternoonSupply;
                dto.TotalAmount =Convert.ToInt32(sumUp);
                dto.TotalMilk = grandMilkTotal;
                var marketPucrchase = await _asyncRepository.AddAsync(_mapper.Map<MarketPurchase>(dto));
                //var market = await _supplierSuppliedRepository.AddMarketSupplierSupplied(
                //        new MarketSupplierSupplied()
                //        {
                //            FkMarketSupplierId = dto.MarketSupplierId,
                //            Morning = dto.Morning,
                //            MorningMilkRate = dto.MorningMilkRate,
                //            Afternoon = dto.Afternoon,
                //            AfternoonMilkRate = dto.AfternoonMilkRate,
                //            MorningAmount = supply.morningsupply,
                //            AfternoonAmount = supply.afternoonSupply,
                //            TotalMilk = grandMilkTotal,
                //            ComissionRate = dto.ComissionRate,
                //            TotalComission = addAllComissionValues,
                //            Debit = dto.Debit,
                //            Credit = Convert.ToString(credit),
                //            Total = Convert.ToString(sumUp, CultureInfo.InvariantCulture),
                //            CreatedOn = dto.CreatedOn.date

                //            CreatedById = dto.CreatedById
                //        });

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
    }
}
