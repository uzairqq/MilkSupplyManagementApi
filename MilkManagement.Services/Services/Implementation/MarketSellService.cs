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

        public async Task<ResponseMessageDto> Delete(MarketSellRequestDto dto)
        {
            try
            {
                 await _asyncRepository.DeleteAsync(_mapper.Map<MarketSell>(dto));
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



        public async Task<ResponseMessageDto> Put(MarketSellRequestDto dto)
        {
            try
            {
                //if (!await _supplierSuppliedRepository.IsMarketSupplierInsertedOnCurrentDate(dto.MarketSupplierId,
                //    dto.MarketSupplierSupplied))
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

                await _asyncRepository.PartialUpdate(dto, m => ///yahan woh values aengi jo ke update karni hongi 
                {
                    m.MarketSupplierId = dto.MarketSupplierId;
                    m.MorningSell = dto.MorningSell;
                    m.MorningRate = dto.MorningRate;
                    m.MorningAmount = dto.MorningAmount;
                    m.AfternoonSell = dto.AfternoonSell;
                    m.AfternoonAmount = dto.AfternoonAmount;
                    m.AfternoonRate = dto.AfternoonRate;
                    m.ComissionRate = dto.ComissionRate;
                    m.TotalComission = dto.TotalComission;
                    m.Total = dto.Total;
                    m.TotalMilk = dto.TotalMilk;
                });
                //var expense = await _supplierSuppliedRepository.UpdateMarketSuppliedSupplied(
                //        new MarketSupplierSupplied()
                //        {
                //            PkMarketSupplierSupplied = dto.MarketSupplierSupplied,
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
                //            LastUpdatedById = dto.LastUpdatedById,
                //            LastUpdatedOn = dto.date,

                //        });
                return new ResponseMessageDto()
                {
                    Id = dto.Id,
                    SuccessMessage = ResponseMessages.UpdateSuccessMessage,
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
                    FailureMessage = ResponseMessages.UpdateFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }
    }
}
