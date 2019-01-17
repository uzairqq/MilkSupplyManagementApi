//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using MilkManagement.CommonLibrary.Functions;
//using MilkManagement.Constants;
//using MilkManagement.Domain.Dto.RequestDto;
//using MilkManagement.Domain.Dto.ResponseDto;
//using MilkManagement.Domain.Entities.Customer;
//using MilkManagement.Domain.Repositories.Interfaces;
//using MilkManagement.Domain.Specification;
//using MilkManagement.Services.Services.Interfaces;

//namespace MilkManagement.Services.Services.Implementation
//{
//    public class CustomerSuppliedServiceService : ICustomerSuppliedService
//    {
//        private readonly IAsyncRepository<CustomerSupplied> _asyncRepository;
//        private readonly IMapper _mapper;
//        private readonly ICustomerSuppliedRepository _customerSuppliedRepository;
//        private readonly ICustomerRateRepository _customerRateRepository;

//        public CustomerSuppliedServiceService(
//            IAsyncRepository<CustomerSupplied> asyncRepository,
//            IMapper mapper,
//            ICustomerSuppliedRepository customerSuppliedRepository,
//            ICustomerRateRepository customerRateRepository)
//        {
//            _asyncRepository = asyncRepository;
//            _mapper = mapper;
//            _customerSuppliedRepository = customerSuppliedRepository;
//            _customerRateRepository = customerRateRepository;
//        }
//        public async Task<ResponseMessageDto> Post(CustomerSuppliedRequestDto dto)
//        {
//            try
//            {
//                if (!_customerSuppliedRepository.IsCustomerRecordAvailableOnParticularDate(
//                    dto.CustomerId))
//                {
//                    var customerCurrentRate = _customerRateRepository.GetCurrentRateByCustomerId(dto.CustomerId);

//                    var supply =
//                        CustomerSuppliedCalculation.GetMorningSupplyAndAfterNoonSupply(dto.MorningSupply,
//                            dto.AfternoonSupply, customerCurrentRate);

//                    var sumUp = Convert.ToDouble(supply.morningsupply) + Convert.ToDouble(supply.afternoonSupply);
//                    dto.Rate = customerCurrentRate;
//                    var credit = sumUp - dto.Debit;
//                    dto.Credit =Convert.ToInt32(credit);
//                    dto.Total = sumUp;
//                    dto.MorningAmount = Convert.ToDouble(supply.morningsupply);
//                    dto.AfternoonAmount = Convert.ToDouble(supply.afternoonSupply);
                    
//                    var customerSupplied = await _asyncRepository.AddAsync(_mapper.Map<CustomerSupplied>(dto));
//                    return new ResponseMessageDto()
//                    {
//                        Id = customerSupplied.Id,
//                        SuccessMessage = ResponseMessages.InsertionSuccessMessage,
//                        Success = true,
//                        Error = false
//                    };
//                }
//                return new ResponseMessageDto()
//                {
//                    Id = Convert.ToInt16(Enums.FailureId),
//                    SuccessMessage = ResponseMessages.CustomerAlreadyInsertedInThisDate,
//                    Success = true,
//                    Error = false
//                };
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                return new ResponseMessageDto()
//                {
//                    Id = Convert.ToInt16(Enums.FailureId),
//                    FailureMessage = ResponseMessages.InsertionFailureMessage,
//                    Success = false,
//                    Error = true,
//                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
//                };
//            }
//        }

//        public async Task<ResponseMessageDto> Put(CustomerSuppliedRequestDto dto)
//        {
//            try
//            {
//                if (!_customerSuppliedRepository.IsCustomerRecordAvailableOnParticularDate(
//                    dto.CustomerId, dto.Id))
//                {
//                    var customerCurrentRate = _customerRateRepository.GetCurrentRateByCustomerId(dto.CustomerId);

//                    var supply =
//                        CustomerSuppliedCalculation.GetMorningSupplyAndAfterNoonSupply(dto.MorningSupply,
//                            dto.AfternoonSupply, customerCurrentRate);

//                    var sumUp = Convert.ToDouble(supply.morningsupply) + Convert.ToDouble(supply.afternoonSupply);
//                    var credit = sumUp - dto.Debit;
//                    dto.Rate = customerCurrentRate;
//                    dto.Credit = Convert.ToInt32(credit);
//                    dto.Total = sumUp;
//                    dto.MorningAmount = Convert.ToDouble(supply.morningsupply);
//                    dto.AfternoonAmount = Convert.ToDouble(supply.afternoonSupply);
//                    await _asyncRepository.UpdateAsync(_mapper.Map<CustomerSupplied>(dto));

//                    return new ResponseMessageDto()
//                    {
//                        Id = dto.Id,
//                        SuccessMessage = ResponseMessages.UpdateSuccessMessage,
//                        Success = true,
//                        Error = false
//                    };
//                }
//                return new ResponseMessageDto()
//                {
//                    Id = Convert.ToInt16(Enums.FailureId),
//                    SuccessMessage = ResponseMessages.CustomerAlreadyInsertedInThisDate,
//                    Success = true,
//                    Error = false
//                };
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                return new ResponseMessageDto()
//                {
//                    Id = Convert.ToInt16(Enums.FailureId),
//                    FailureMessage = ResponseMessages.InsertionFailureMessage,
//                    Success = false,
//                    Error = true,
//                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
//                };
//            }

//        }
//        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> Get()
//        //{
//        //    try
//        //    {
//        //        var customerSupplied = await _asyncRepository.ListAsync<CustomerSuppliedResponseDto>(new CustomerSuppliedWithType());
//        //        return customerSupplied;

//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Console.WriteLine(e);
//        //        throw;
//        //    }
//        //}

//        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByDate(DateTime date)
//        //{
//        //    try
//        //    {
//        //        var customerSupplied = await _customerSuppliedRepository.GetCustomerSuppliedByDate(date);
//        //        return customerSupplied;
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Console.WriteLine(e);
//        //        throw;
//        //    }
//        //}

//        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerId(int customerId)
//        //{
//        //    try
//        //    {
//        //        return await _customerSuppliedRepository.GetCustomerSuppliedByCustomerId(customerId);
               
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Console.WriteLine(e);
//        //        throw;
//        //    }
//        //}
//        public async Task<CustomerSuppliedResponseDto> GetCustomerSuppliedByCustomerSuppliedId(int customerSuppliedId)
//        {
//            try
//            {
//                return await _asyncRepository.GetByIdAsync<CustomerSuppliedResponseDto>(customerSuppliedId);

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByStartAndEndDate(DateTime startDate, DateTime endDate)
//        //{
//        //    try
//        //    {
//        //        var customerSupplied = await _customerSuppliedRepository.GetCustomerSuppliedByStartAndEndDate(startDate, endDate);
//        //        return customerSupplied;
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Console.WriteLine(e);
//        //        throw;
//        //    }
//        //}
//        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdAndParticularDate(int customerId, DateTime date)
//        //{
//        //    try
//        //    {
//        //        return await _customerSuppliedRepository.GetCustomerSuppliedByCustomerIdAndParticularDate(customerId, date);
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Console.WriteLine(e);
//        //        throw;
//        //    }
//        //}
//        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdStartDateAndEndDate(int customerId, DateTime startDate, DateTime endDate)
//        //{
//        //    try
//        //    {
//        //        return await _customerSuppliedRepository.GetCustomerSuppliedByCustomerIdStartDateAndEndDate(customerId, startDate, endDate);
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Console.WriteLine(e);
//        //        throw;
//        //    }
//        //}
//        public async Task<ResponseMessageDto> Delete(CustomerSuppliedRequestDto dto)
//        {
//            try
//            {

//                await _asyncRepository.DeleteAsync(_mapper.Map<CustomerSupplied>(dto));
//                return new ResponseMessageDto()
//                {
//                    Id = dto.Id,
//                    SuccessMessage = ResponseMessages.DeleteSuccessMessage,
//                    Success = true,
//                    Error = false
//                };
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                return new ResponseMessageDto()
//                {
//                    Id = Convert.ToInt16(Enums.FailureId),
//                    FailureMessage = ResponseMessages.InsertionFailureMessage,
//                    Success = false,
//                    Error = true,
//                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
//                };
//            }
//        }




//    }
//}
