using System;
using System.Collections.Generic;
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
    public class SupplierRatesServices : ISupplierRateServices
    {
        private readonly IAsyncRepository<SupplierRate> _asyncRepository;
        private readonly ISupplierRateRepository _supplierRateRepository;
        private readonly IMapper _mapper;

        public SupplierRatesServices(IAsyncRepository<SupplierRate> asyncRepository, ISupplierRateRepository supplierRateRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _supplierRateRepository = supplierRateRepository;
            _mapper = mapper;
        }
        public async Task<ResponseMessageDto> Post(SupplierRatesRequestDto dto)
        {
            try
            {
                if (await _supplierRateRepository.IsRatesAssignedToSupplier(dto.SupplierId))
                    return new ResponseMessageDto()
                    {
                        FailureMessage = ResponseMessages.RatesAssignedToSupplier,
                        Success = false,
                        Error = true
                    };
                var supp = await _asyncRepository.AddAsync(_mapper.Map<SupplierRate>(dto));
                _supplierRateRepository.SetIsSupplierRateAssigned(dto.SupplierId, true);
                return new ResponseMessageDto()
                {
                    Id = supp.Id,
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

        public async Task<ResponseMessageDto> Put(SupplierRatesRequestDto dto)
        {
            try
            {
                if (!await _supplierRateRepository.IsRatesAssignedToSupplier(dto.Id, dto.SupplierId))
                {
                    //await _asyncRepository.UpdateAsync(_mapper.Map<SupplierRate>(dto));
                    await _asyncRepository.PartialUpdate(dto, m => ///yahan woh values aengi jo ke update karni hongi 
                    {
                        m.CurrentRate = dto.CurrentRate;
                        m.PreviousRate = dto.PreviousRate;
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
                    SuccessMessage = ResponseMessages.RatesAssignedToSupplier,
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

        public async Task<ResponseMessageDto> Delete(SupplierRatesRequestDto dto)
        {
            try
            {
                await _asyncRepository.DeleteAsync(_mapper.Map<SupplierRate>(dto));
                _supplierRateRepository.SetIsSupplierRateAssigned(dto.SupplierId, false);
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

        public async Task<IEnumerable<GetSupplierRateResponseDto>> GetAll()
        {
            try
            {
                var result = await _asyncRepository.ListAsync<GetSupplierRateResponseDto>(new SupplierWithName());
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<GetSupplierRateResponseDto> GetBySupplierRateId(int supplierRateId)
        {
            try
            {
                return await _asyncRepository.GetByIdAsync<GetSupplierRateResponseDto>(supplierRateId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<GetSupplierRateResponseDto> GetBySupplierId(int supplierId)
        {
            try
            {
                return await _asyncRepository.GetByIdAsync<GetSupplierRateResponseDto>(supplierId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> IsRatesAssignedToSupplier(int supplierId)
        {
            try
            {
                return await _supplierRateRepository.IsRatesAssignedToSupplier(supplierId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<GetCurrentRateBySupplierIdDto> GetCurrentRateBySupplierIdDropDown(int suppId)
        {
            try
            {
                return await _supplierRateRepository.GetCurrentRateBySupplierIdDropDown(suppId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<GetSupplierRatesDropdownDto>> GetDropDownSuppliers()
        {
            try
            {
                return await _supplierRateRepository.GetAllSupplierForDropdown();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
