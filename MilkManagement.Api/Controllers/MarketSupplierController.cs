using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketSupplierController : ControllerBase
    {
        private readonly IMarketSupplierService _marketSupplierService;

        public MarketSupplierController(IMarketSupplierService marketSupplierService) 
        {
            _marketSupplierService = marketSupplierService;
        }

        /// <summary>
        /// Customer Post
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MarketSupplierRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _marketSupplierService.Post(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// To Update Customer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MarketSupplierRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _marketSupplierService.Put(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}