using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MilkManagement.Constants;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Entities.Customer;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Services.Services.Implementation
{
   public class CustomerSuppliedService:ICustomerSupplied
    {
        private readonly IAsyncRepository<CustomerSupplied> _asyncRepository;
        private readonly IMapper _mapper;

        public CustomerSuppliedService(IAsyncRepository<CustomerSupplied> asyncRepository,IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }
        //public async Task<ResponseMessageDto> Post(CustomerSuppliedRequestDto dto)
        //{
        //    try
        //    {
        //       //await _asyncRepository.AddAsync(_mapper.Map<CustomerSuppliedRequestDto>(dto));
        //    }
        //    catch (Exception e)
        //    {
        //            Console.WriteLine(e);
        //            throw;
        //    }
        //}
    }
}
