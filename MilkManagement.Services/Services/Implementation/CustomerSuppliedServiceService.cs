using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MilkManagement.CommonLibrary.Functions;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Customer;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Domain.Specification;
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
                    dto.CustomerId,dto.CreatedOn.Date))
                {
                    var customerCurrentRate = _customerRateRepository.GetCurrentRateByCustomerId(dto.CustomerId);

                    var supply =
                        CustomerSuppliedCalculation.GetMorningSupplyAndAfterNoonSupply(dto.MorningSupply,
                            dto.AfternoonSupply, customerCurrentRate);

                    var sumUp = Convert.ToDouble(supply.morningsupply) + Convert.ToDouble(supply.afternoonSupply);
                    dto.Rate = customerCurrentRate;
                    var credit = sumUp - dto.Debit;
                    dto.Credit = Convert.ToInt32(credit);
                    dto.Total = sumUp;
                    dto.MorningAmount = Convert.ToDouble(supply.morningsupply);
                    dto.AfternoonAmount = Convert.ToDouble(supply.afternoonSupply);

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
                    FailureMessage = ResponseMessages.CustomerAlreadyInsertedInThisDate,
                    Success = false,
                    Error = true
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


        public async Task<ResponseMessageDto> Put(CustomerSuppliedRequestDto dto)
        {
            try
            {
                if (!_customerSuppliedRepository.IsCustomerRecordAvailableOnParticularDate(
                    dto.CustomerId, dto.Id,dto.CreatedOn.Date))
                {
                    var customerCurrentRate = _customerRateRepository.GetCurrentRateByCustomerId(dto.CustomerId);

                    var supply =
                        CustomerSuppliedCalculation.GetMorningSupplyAndAfterNoonSupply(dto.MorningSupply,
                            dto.AfternoonSupply, customerCurrentRate);

                    var sumUp = Convert.ToDouble(supply.morningsupply) + Convert.ToDouble(supply.afternoonSupply);
                    var credit = sumUp - dto.Debit;
                    dto.Rate = customerCurrentRate;
                    dto.Credit = Convert.ToInt32(credit);
                    dto.Total = sumUp;
                    dto.MorningAmount = Convert.ToDouble(supply.morningsupply);
                    dto.AfternoonAmount = Convert.ToDouble(supply.afternoonSupply);
                    //await _asyncRepository.UpdateAsync(_mapper.Map<CustomerSupplied>(dto));
                    await _asyncRepository.PartialUpdate(dto, m => ///yahan woh values aengi jo ke update karni hongi 
                    {
                        //m.CustomerTypeId = dto.CustomerTypeId;
                        m.CustomerId = dto.CustomerId;
                        m.MorningSupply = dto.MorningSupply;
                        m.MorningAmount = dto.MorningAmount;
                        m.AfternoonSupply = dto.AfternoonSupply;
                        m.AfternoonAmount = dto.AfternoonAmount;
                        m.Rate = Convert.ToInt32(dto.Rate);
                        m.Debit = dto.Debit;
                        m.Credit = dto.Credit;
                        m.Total = dto.Total;
                    });

                    return new ResponseMessageDto()
                    {
                        Id = dto.Id,
                        SuccessMessage = ResponseMessages.UpdateSuccessMessage,
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
        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> Get()
        //{
        //    try
        //    {
        //        var customerSupplied = await _asyncRepository.ListAsync<CustomerSuppliedResponseDto>(new CustomerSuppliedWithType());
        //        return customerSupplied;

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

        public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByDate(DateTime date)
        {
            try
            {
                var customerSupplied = await _customerSuppliedRepository.GetCustomerSuppliedByDate(date);
                return customerSupplied;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerId(int customerId)
        //{
        //    try
        //    {
        //        return await _customerSuppliedRepository.GetCustomerSuppliedByCustomerId(customerId);

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        public async Task<CustomerSuppliedResponseDto> GetCustomerSuppliedByCustomerSuppliedId(int customerSuppliedId)
        {
            try
            {
                return await _asyncRepository.GetByIdAsync<CustomerSuppliedResponseDto>(customerSuppliedId);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByStartAndEndDate(DateTime startDate, DateTime endDate)
        //{
        //    try
        //    {
        //        var customerSupplied = await _customerSuppliedRepository.GetCustomerSuppliedByStartAndEndDate(startDate, endDate);
        //        return customerSupplied;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdAndParticularDate(int customerId, DateTime date)
        //{
        //    try
        //    {
        //        return await _customerSuppliedRepository.GetCustomerSuppliedByCustomerIdAndParticularDate(customerId, date);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByCustomerIdStartDateAndEndDate(int customerId, DateTime startDate, DateTime endDate)
        //{
        //    try
        //    {
        //        return await _customerSuppliedRepository.GetCustomerSuppliedByCustomerIdStartDateAndEndDate(customerId, startDate, endDate);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        public async Task<ResponseMessageDto> Delete(CustomerSuppliedRequestDto dto)
        {
            try
            {

                await _asyncRepository.DeleteAsync(_mapper.Map<CustomerSupplied>(dto));
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

        public async Task<IEnumerable<GeCustomerSuppliedtDropDownValuesDto>> GeCustomerSuppliedtDropDownValues(int typeId,DateTime dateTime)
        {
            try
            {
                var result = await _customerSuppliedRepository.GeCustomerSuppliedtDropDownValues(typeId, dateTime);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ResponseMessageDto> ListPost(IEnumerable<CustomerSuppliedRequestDto> customerSupplied, DateTime date)
        {
            try
            {
                var customerSuppliedRequestDtos = customerSupplied.ToList();
                foreach (var dto in customerSuppliedRequestDtos)
                {
                    var customerCurrentRate = _customerRateRepository.GetCurrentRateByCustomerId(dto.CustomerId);

                    var supply =
                        CustomerSuppliedCalculation.GetMorningSupplyAndAfterNoonSupply(dto.MorningSupply,
                            dto.AfternoonSupply, customerCurrentRate);

                    var sumUp = Convert.ToDouble(supply.morningsupply) + Convert.ToDouble(supply.afternoonSupply);
                    dto.Rate = customerCurrentRate;
                    dto.Debit = 0;
                    var credit = sumUp - dto.Debit;
                    dto.Credit = Convert.ToInt32(credit);
                    dto.Total = sumUp;
                    dto.MorningAmount = Convert.ToDouble(supply.morningsupply);
                    dto.AfternoonAmount = Convert.ToDouble(supply.afternoonSupply);
                  
                }
                var model = customerSuppliedRequestDtos.Select(i => new CustomerSupplied()
                {
                    CustomerId = i.CustomerId,
                    CustomerTypeId = i.CustomerTypeId,
                    MorningSupply = i.MorningSupply,
                    AfternoonSupply = i.AfternoonSupply,
                    CreatedOn = date.Date,
                    Rate = Convert.ToInt32(i.Rate),
                    MorningAmount = i.MorningAmount,
                    AfternoonAmount = i.AfternoonAmount,
                    Credit = i.Credit,
                    Debit = i.Debit,
                    Total = i.Total
                });

                var result = await _customerSuppliedRepository.ListPost(model);
                return new ResponseMessageDto()
                {
                    Id = result,
                    SuccessMessage = ResponseMessages.CustomerSuppliedListSuccessfullyInserted,
                    Success = true,
                    Error = false
                };
            }
            catch (Exception e)
            {
                return new ResponseMessageDto()
                {
                    Id = Convert.ToInt16(Enums.FailureId),
                    FailureMessage = ResponseMessages.CustomerSuppliedListFailed,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        public async Task<IEnumerable<GetFastEntryResponseDto>> GetFashEntryData(DateTime date)
        {
            try
            {
                var result = await _customerSuppliedRepository.GetFashEntryData(date);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
