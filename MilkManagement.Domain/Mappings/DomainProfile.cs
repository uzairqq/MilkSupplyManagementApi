using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Entities.Customer;

namespace MilkManagement.Domain.Mappings
{
   public class DomainProfile: Profile
    {
        public DomainProfile()
        {
        CreateMap<Customer, CustomerRequestDto>().ReverseMap();
        }
    }
}
