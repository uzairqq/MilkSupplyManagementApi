using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MilkManagement.Domain.Dto;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Api.Controllers {

    [Route ("api/[controller]")]
    public class LedgerController : Controller {
        private readonly ILedgerService _ledgerService;
        private readonly ILogger<LedgerController> _logger;

        public LedgerController (ILogger<LedgerController> logger,
            ILedgerService ledgerService) {
            _logger = logger;
            _ledgerService = ledgerService;
        }

        [HttpGet ("selectedDate/{date}")]
        public async Task<IActionResult> Get ([FromRoute] DateTime date) {
            try {
                var result = await _ledgerService.Get (date);
                return Ok (result);
            } catch (Exception ex) {
                _logger.LogError (ex.ToString ());
                return BadRequest ();
            }
        }
    }
}