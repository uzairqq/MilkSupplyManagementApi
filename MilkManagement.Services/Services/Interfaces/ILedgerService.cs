using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MilkManagement.Domain.Dto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Services.Services.Interfaces {
    public interface ILedgerService {
        Task<LedgerDto> Get (DateTime date);
    }
}