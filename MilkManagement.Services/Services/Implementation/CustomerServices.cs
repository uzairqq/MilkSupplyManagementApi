using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Customer;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Domain.Specification;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Services.Services.Implementation
{
   public class CustomerServices:ICustomerService
    {
        private readonly IAsyncRepository<Customer> _asyncRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerServices(IAsyncRepository<Customer> asyncRepository,ICustomerRepository customerRepository,IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<List<CustomerResponseDto>> GetAll()
        {
            try
            {
                var customer = _asyncRepository.ListAsync<CustomerResponseDto>(new CustomerWithType());
                return await customer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseMessageDto> AddCustomer(CustomerRequestDto dto)
        {
            try
            {
                if (_customerRepository.IsCustomerNameAvailable(dto.Name))
                    return new ResponseMessageDto()
                    {
                        SuccessMessage = ResponseMessages.CustomerNameNotAvailable,
                        Success = true,
                        Error = false
                    };
                var customer= await _asyncRepository.AddAsync(_mapper.Map<Customer>(dto));
                return new ResponseMessageDto()
                {
                    Id = customer.Id,
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
    
        public async  Task<CustomerResponseDto> GetCustomerById(int customerId)
        {
            try
            {
                return await _asyncRepository.GetSingleAsync<CustomerResponseDto>(new CustomerWithType(customerId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<ResponseMessageDto> DeleteCustomer(CustomerRequestDto dto)
        {
            try
            {
                await _asyncRepository.DeleteAsync(_mapper.Map<Customer>(dto));
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

        public async Task<ResponseMessageDto> UpdateCustomer(CustomerRequestDto dto)
        {
            try
            {
                if ( _customerRepository.IsCustomerNameAvailable(dto.Id, dto.Name))
                    return new ResponseMessageDto()
                    {
                        SuccessMessage = ResponseMessages.CustomerNameNotAvailable,
                        Success = true,
                        Error = false
                    };
                await _asyncRepository.UpdateAsync(_mapper.Map<Customer>(dto));
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

        public ResponseMessageDto IsCustomerNameAvailable(string customerName)
        {
            try
            {
                var result = _customerRepository.IsCustomerNameAvailable(customerName);
                if (result)
                    return new ResponseMessageDto()
                    {
                        SuccessMessage = ResponseMessages.CustomerNameNotAvailable,
                        Success = true,
                        Error = false
                    };
                return new ResponseMessageDto()
                {
                    SuccessMessage = ResponseMessages.CustomerNameAvailable,
                    Success = true,
                    Error = false
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ResponseMessageDto()
                {
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }


    }
}
