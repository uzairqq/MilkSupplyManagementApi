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
    public class MarketSellController : ControllerBase
    {
        private readonly IMarketSellService _marketSellService;
        public MarketSellController(IMarketSellService marketSellService)
        {
            _marketSellService = marketSellService;
        }
        /// <summary>
        /// Post Market Supplier Supplied
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MarketSellRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _marketSellService.Post(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Put Market Supplier Supplied
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MarketSellRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _marketSellService.Put(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] MarketSellRequestDto dto)
        {
            try
            {
                return Ok(await _marketSellService.Delete(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("grid/date/{date}")]
        public async Task<IActionResult> GetByCurrentDate([FromRoute] DateTime date)
        {
            try
            {
                return Ok(await _marketSellService.GetGridData(date));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpGet("marketSupplierId/{marketSupplierId}/fromDate/{fromDate}/toDate/{toDate}")]
        public async Task<IActionResult> GetMarketSupplierByParticularDate([FromRoute] int marketSupplierId, [FromRoute] DateTime fromDate,
         [FromRoute] DateTime toDate)
        {
            try
            {
                var result=await _marketSellService.GetMarketSupplierByParticularDate(marketSupplierId,
                    fromDate, toDate);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}