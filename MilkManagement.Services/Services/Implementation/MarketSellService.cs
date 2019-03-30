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
        private readonly IMarketSellRepository _marketSell;
        public MarketSellService(IAsyncRepository<MarketSell> asyncRepository, IMapper mapper, IMarketSellRepository marketSell)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _marketSell = marketSell;
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

        public async Task<IEnumerable<MarketSellResponseDto>> GetGridData(DateTime date)
        {
            try
            {
                var result = await _marketSell.GetGrid(date);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }



        public Task<ResponseMessageDto> Put(MarketSellRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
