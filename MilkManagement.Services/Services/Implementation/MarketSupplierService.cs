using AutoMapper;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Entities.Market;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Services.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MilkManagement.Services.Services.Implementation
{
    public class MarketSupplierService : IMarketSupplierService
    {
        private readonly IAsyncRepository<MarketSupplier> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly IMarketSupplierRepository _marketSupplierRepository;

        public MarketSupplierService(IAsyncRepository<MarketSupplier> asyncRepository, IMapper mapper, IMarketSupplierRepository marketSupplierRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _marketSupplierRepository = marketSupplierRepository;
        }

        public async Task<ResponseMessageDto> Post(MarketSupplierRequestDto dto)
        {
            try
            {
                if (await _marketSupplierRepository.IsMarketSupplierNameAvailable(dto.MarketSupplierName))
                    return new ResponseMessageDto()
                    {
                        FailureMessage = ResponseMessages.MarketSupplierNameNotAvailable,
                        Success = false,
                        Error = true
                    };
                dto.CreatedOn = DateTime.Now.Date;
                var markerSupplier = await _asyncRepository.AddAsync(_mapper.Map<MarketSupplier>(dto));
                return new ResponseMessageDto()
                {
                    Id = markerSupplier.Id,
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

        public async Task<ResponseMessageDto> Put(MarketSupplierRequestDto dto)
        {
            try
            {
                if (await _marketSupplierRepository.IsMarketSupplierNameAvailable(dto.Id, dto.MarketSupplierName))
                    return new ResponseMessageDto()
                    {
                        SuccessMessage = ResponseMessages.MarketSupplierNameNotAvailable,
                        Success = true,
                        Error = false
                    };
                await _asyncRepository.PartialUpdate(dto, m => ///yahan woh values aengi jo ke update karni hongi 
                {
                    m.MarketSupplierName = dto.MarketSupplierName;
                    m.MarketSupplierAddress= dto.MarketSupplierAddress;
                    m.MarketSupplierContact = dto.MarketSupplierContact;
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
    
    
