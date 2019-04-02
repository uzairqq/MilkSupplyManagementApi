using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierSuppliedController : ControllerBase
    {
        private readonly ISupplierSuppliedServices _supplierSuppliedServices;
        public SupplierSuppliedController(ISupplierSuppliedServices supplierSuppliedServices)
        {
            _supplierSuppliedServices = supplierSuppliedServices;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SupplierSuppliedRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _supplierSuppliedServices.Post(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("gridWithDate/date/{date}")]
        public async Task<IActionResult> GetGrid([FromRoute] DateTime date)
        {
            try
            {
                return Ok(await _supplierSuppliedServices.GetGrid(date));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        [HttpPut]
        public async Task<IActionResult> Put(SupplierSuppliedRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _supplierSuppliedServices.Put(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("supplierSuppliedDropDown/date/{date}")]
        public async Task<IActionResult> GetDropDown([FromRoute] DateTime date)
        {
            try
            {
                var result = await _supplierSuppliedServices.GetDropDown(date);
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpGet("GetDropDownForSearch")]
        public async Task<IActionResult> GetDropDownForSearch()
        {
            try
            {
                var result = await _supplierSuppliedServices.GetDropDownForSearch();
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] SupplierSuppliedRequestDto dto)
        {
            try
            {
                return Ok(await _supplierSuppliedServices.Delete(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Get By Supplier Id With From And To date
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet("supplierId/{supplierId}/fromDate/{fromDate}/toDate/{toDate}")]
        public async Task<IActionResult> Get([FromRoute] int supplierId, [FromRoute] DateTime fromDate, DateTime toDate)
        {
            try
            {
                return Ok(await _supplierSuppliedServices.GetSuppliersDataToAndFromDate(supplierId, fromDate, toDate));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}