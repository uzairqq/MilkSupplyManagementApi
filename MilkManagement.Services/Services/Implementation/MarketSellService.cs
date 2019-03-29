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
    public class MarketSellService : IMarketSellService
    {
        private readonly IAsyncRepository<MarketSell> _asyncRepository;
        private readonly IMapper _mapper;
        public MarketSellService(IAsyncRepository<MarketSell> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<ResponseMessageDto> Post(MarketSellRequestDto dto)
        {
            try
            {
                //if (!await _supplierSuppliedRepository.IsMarketSupplierInsertedOnCurrentDate(dto.MarketSupplierId))
                //{

                var (morningsupply, afternoonSupply) =
                    MarketSellCalculate.GetMorningSupplyAndAfterNoonSupply(dto.MorningSell,
                            dto.AfternoonSell, Convert.ToInt32(dto.MorningRate), Convert.ToInt32(dto.AfternoonRate));
                var sumUp = Convert.ToDouble(morningsupply) +
                            Convert.ToDouble(afternoonSupply);
                int addAllComissionValues = SupplierCommissionCalculate.SupplierComissionCalulate(dto.MorningSell, dto.AfternoonSell, dto.ComissionRate);
                string grandMilkTotal = TotalMilkCalculate.TotalMilkCalulate(dto.MorningSell, dto.AfternoonSell);
                dto.MorningAmount = morningsupply;
                dto.AfternoonAmount = afternoonSupply;
                dto.TotalComission = addAllComissionValues;
                dto.Total = sumUp.ToString();
                dto.TotalMilk = grandMilkTotal;
                dto.CreatedOn = dto.CreatedOn;
                var marketSell = await _asyncRepository.AddAsync(_mapper.Map<MarketSell>(dto));

                //var market = await _asyncRepository.AddMarketSupplierSupplied(
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
                //            CreatedOn = dto.date,
                //            CreatedById = dto.CreatedById
                //        });

                return new ResponseMessageDto()
                {
                    Id = marketSell.Id,
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

        public Task<ResponseMessageDto> Delete(MarketSellRequestDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MarketSellResponseDto>> GetGridData(DateTime date)
        {
            throw new NotImplementedException();
        }



        public Task<ResponseMessageDto> Put(MarketSellRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
