using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Supplier;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Services.Services.Implementation
{
    public class SupplierService : ISupplierService
    {
        private readonly IAsyncRepository<Supplier> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(IAsyncRepository<Supplier> asyncRepository, IMapper mapper,
            ISupplierRepository supplierRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<ResponseMessageDto> Post(AddSupplierRequestDto dto)
        {
            try
            {
                if (!await _supplierRepository.IsSupplierNameAvailable(dto.SupplierName))
                {
                    dto.CreatedOn = DateTime.Now.Date;
                    var supplier = await _asyncRepository.AddAsync(_mapper.Map<Supplier>(dto));
                    return new ResponseMessageDto()
                    {
                        Id = supplier.Id,
                        SuccessMessage = ResponseMessages.InsertionSuccessMessage,
                        Success = true,
                        Error = false
                    };
                }

                return new ResponseMessageDto()
                {
                    FailureMessage = ResponseMessages.SupplierNameNotAvailable,
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

        public async Task<ResponseMessageDto> Put(AddSupplierRequestDto dto)
        {
            try
            {
                if (!await _supplierRepository.IsSupplierNameAvailable(dto.Id, dto.SupplierName))
                {
                    await _asyncRepository.PartialUpdate(dto, m => ///yahan woh values aengi jo ke update karni hongi 
                    {
                        m.SupplierName = dto.SupplierName;
                        m.SupplierAddress = dto.SupplierAddress;
                        m.SupplierContact = dto.SupplierContact;
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
                    FailureMessage = ResponseMessages.SupplierNameNotAvailable,
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
                    FailureMessage = ResponseMessages.UpdateFailureMessage,
                    Success = false,
                    Error = true,
                    ExceptionMessage = e.InnerException != null ? e.InnerException.Message : e.Message
                };
            }
        }

        public async Task<ResponseMessageDto> Delete(AddSupplierRequestDto dto)
        {
            try
            {
                await _asyncRepository.DeleteAsync(_mapper.Map<Supplier>(dto));
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

        public async Task<IEnumerable<SupplierResponseDto>> GetAll()
        {
            try
            {
                return await _asyncRepository.ListAllAsync<SupplierResponseDto>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<SupplierResponseDto> GetById(int supplierId)
        {
            try
            {
                return await _asyncRepository.GetByIdAsync<SupplierResponseDto>(supplierId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> IsSupplierNameAvailable(string name)
        {
            return await _supplierRepository.IsSupplierNameAvailable(name);
        }
    }
}

