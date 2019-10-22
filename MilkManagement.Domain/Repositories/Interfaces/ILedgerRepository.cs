using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MilkManagement.Domain.Dto;
using MilkManagement.Domain.Dto.ResponseDto;

namespace MilkManagement.Domain.Repositories.Interfaces
{
    public interface ILedgerRepository
    {
        Task<LedgerDto> Get(DateTime date);
    }
}
