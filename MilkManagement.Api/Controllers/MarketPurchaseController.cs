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
    public class MarketPurchaseController : ControllerBase
    {
        private readonly IMarketPurchaseService _marketPurchase;
        public MarketPurchaseController(IMarketPurchaseService marketPurchase)
        {
            _marketPurchase = marketPurchase;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MarketPurchaseRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _marketPurchase.Post(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("drpDownAll/date/{date}")]
        public async Task<IActionResult> Get([FromRoute] DateTime date)
        {
            try
            {
                var result = await _marketPurchase.GeCustomerSuppliedtDropDownValues(date);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        [HttpGet("marketSupplierId/{marketSupplierId}/fromDate/{fromDate}/toDate/{toDate}")]
        public async Task<IActionResult> GetMarketSupplierByParticularDate([FromRoute] int marketSupplierId, [FromRoute] DateTime fromDate,
         [FromRoute] DateTime toDate)
        {
            try
            {
                var result=await _marketPurchase.GetMarketSupplierByParticularDate(marketSupplierId,
                    fromDate, toDate);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("grid/date/{date}")]
        public async Task<IActionResult> GetGrid([FromRoute] DateTime date)
        {
            try
            {
                var result = await _marketPurchase.GetGrid(date);
                return Ok(result);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MarketPurchaseRequestDto dto)
        {
            try
            {
                var result = await _marketPurchase.Put(dto);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] MarketPurchaseRequestDto dto)
        {
            try
            {
                var result = await _marketPurchase.Delete(dto);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }




    }
}