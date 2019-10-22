using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MilkManagement.Domain.Dto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Domain.Repositories.Interfaces;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Services.Services.Implementation {
    public class LedgerService : ILedgerService {
        private readonly ILogger<LedgerService> _logger;
        private readonly ILedgerRepository _ledgerRepository;

        public LedgerService (ILedgerRepository ledgerRepository, ILogger<LedgerService> logger) {
            _ledgerRepository = ledgerRepository;
            _logger = logger;
        }
        public async Task<LedgerDto> Get (DateTime date) {
            try {
                var result = await _ledgerRepository.Get (date);
                return result;
            } catch (Exception ex) {
                _logger.LogError (ex.ToString ());
                throw;
            }
        }
    }
}