using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MilkManagement.CommonLibrary.Functions;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Entities.Customer;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Services.Services.Implementation
{
    public class CustomerSuppliedServiceService : ICustomerSuppliedService
    {
        private readonly IAsyncRepository<CustomerSupplied> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly ICustomerSuppliedRepository _customerSuppliedRepository;
        private readonly ICustomerRateRepository _customerRateRepository;

        public CustomerSuppliedServiceService(
            IAsyncRepository<CustomerSupplied> asyncRepository,
            IMapper mapper,
            ICustomerSuppliedRepository customerSuppliedRepository,
            ICustomerRateRepository customerRateRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _customerSuppliedRepository = customerSuppliedRepository;
            _customerRateRepository = customerRateRepository;
        }
        public async Task<ResponseMessageDto> Post(CustomerSuppliedRequestDto dto)
        {
            try
            {
                if (!_customerSuppliedRepository.IsCustomerRecordAvailableOnParticularDate(
                    dto.CustomerId))
                {
                    var customerCurrentRate = _customerRateRepository.GetCurrentRateByCustomerId(dto.CustomerId);

                    var supply =
                        CustomerSuppliedCalculation.GetMorningSupplyAndAfterNoonSupply(dto.MorningSupply,
                            dto.AfternoonSupply, customerCurrentRate);

                    var sumUp = Convert.ToDouble(supply.morningsupply) + Convert.ToDouble(supply.afternoonSupply);
                    var credit = sumUp - dto.Debit;
                    dto.Credit =Convert.ToInt32(credit);
                    dto.Total = sumUp;
                    dto.MorningSupply = supply.morningsupply;
                    dto.AfternoonSupply = supply.afternoonSupply;
                    var customerSupplied = await _asyncRepository.AddAsync(_mapper.Map<CustomerSupplied>(dto));
                    return new ResponseMessageDto()
                    {
                        Id = customerSupplied.Id,
                        SuccessMessage = ResponseMessages.InsertionSuccessMessage,
                        Success = true,
                        Error = false
                    };
                }
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    SuccessMessage = ResponseMessages.CustomerAlreadyInsertedInThisDate,
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
    }
}
