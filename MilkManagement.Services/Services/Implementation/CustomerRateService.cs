using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Entities.Customer;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Services.Services.Implementation
{
   public class CustomerRateService:ICustomerRateService
    {
        private readonly IAsyncRepository<CustomerRates> _asyncRepository;
        private readonly ICustomerRateRepository _customerRateRepository;
        private readonly IMapper _mapper;

        public CustomerRateService(IAsyncRepository<CustomerRates> asyncRepository,ICustomerRateRepository customerRateRepository,IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _customerRateRepository = customerRateRepository;
            _mapper = mapper;
        }
           public async Task<ResponseMessageDto> AddCustomerRates(CustomerRatesRequestDto dto)
        {
            try
            {
                if (!_customerRateRepository.IsRateAssignedToCustomer(dto.CustomerId))
                    return new ResponseMessageDto()
                    {
                        SuccessMessage = ResponseMessages.RatesAssignedToCustomer,
                        Success = true,
                        Error = false
                    };

                var customerRates = await _asyncRepository.AddAsync(_mapper.Map<CustomerRates>(dto));
                return new ResponseMessageDto()
                {
                    Id = customerRates.Id,
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

        public async Task<ResponseMessageDto> UpdateCustomerRates(CustomerRatesRequestDto dto)
        {
            try
            {
                if (_customerRateRepository.IsRateAssignedToCustomer(dto.CustomerId, dto.Id))
                    return new ResponseMessageDto()
                    {
                        SuccessMessage = ResponseMessages.RatesAssignedToCustomer,
                        Success = true,
                        Error = false
                    };

                await _asyncRepository.UpdateAsync(_mapper.Map<CustomerRates>(dto));
                 
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

        public async Task<IEnumerable<CustomerRatesResponseDto>> GetAllCustomerRates()
        {
            try
            {
                return await _asyncRepository.ListAllAsync<CustomerRatesResponseDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<CustomerRatesResponseDto> GetCustomerRatesById(int customerRatesId)
        {
            try
            {

                return await _asyncRepository.GetByIdAsync<CustomerRatesResponseDto>(customerRatesId);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        


        //public async Task<CustomerRatesDto> GetCustomerRatesByCustomerRateId(int customerRateId)
        //{
        //    //try
        //    //{
        //    //    var customerRates = await _customerRateRepository.GetCustomerRatesByCustomerRatesId(customerRateId);
        //    //    return customerRates;
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    Console.WriteLine(e);
        //    //    throw;
        //    //}
        //}

        public async Task<ResponseMessageDto> DeleteCustomerRates(CustomerRatesRequestDto dto)
        {
            try
            {
              
                await _asyncRepository.DeleteAsync(_mapper.Map<CustomerRates>(dto));
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

        public bool IsRateAssignedToCustomer(int customerId)
        {
            try
            {
                return _customerRateRepository.IsRateAssignedToCustomer(customerId);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //public async Task<GetCurrentRateByCustomerIdDto> GetCurrentRateByCustomerIdDropDown(int custId)
        //{
        //    try
        //    {
        //        return await _customerRateRepository.GetCurrentRateByCustomerIdDropDown(custId);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

    }
}
