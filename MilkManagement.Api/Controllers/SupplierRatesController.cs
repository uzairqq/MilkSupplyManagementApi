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
    public class SupplierRatesController : ControllerBase
    {
        private readonly ISupplierRateServices _supplierRateServices;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierRateServices"></param>
        public SupplierRatesController(ISupplierRateServices supplierRateServices)
        {
            _supplierRateServices = supplierRateServices;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SupplierRatesRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _supplierRateServices.Post(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Update Supplier Rates
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SupplierRatesRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _supplierRateServices.Put(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Delete Supplier Rate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                return Ok(await _supplierRateServices.Delete(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Supplier Rate Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _supplierRateServices.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Get By Supplier Rate Id
        /// </summary>
        /// <param name="supplierRateId"></param>
        /// <returns></returns>
        [HttpGet("supplierRateId/{supplierRateId}")]
        public async Task<IActionResult> Get([FromRoute] int supplierRateId)
        {
            try
            {
                return Ok(await _supplierRateServices.GetBySupplierRateId(supplierRateId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpGet("supplierId/{supplierId}")]
        public async Task<IActionResult> GetBySupplierId([FromRoute] int supplierId)
        {
            try
            {
                return Ok(await _supplierRateServices.GetBySupplierId(supplierId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Is Rates Assigned To Supplier
        /// </summary>
        /// <param name="suppId"></param>
        /// <returns></returns>
        [HttpGet("suppId/{suppId}")]
        public async Task<IActionResult> GetRate([FromRoute] int suppId)
        {
            try
            {
                return Ok(await _supplierRateServices.IsRatesAssignedToSupplier(suppId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpGet("DrpDown/suppId/{suppId}")]
        public async Task<IActionResult> GetCurrentRateBySupplierId([FromRoute] int suppId)
        {
            try
            {
                return Ok(await _supplierRateServices.GetCurrentRateBySupplierIdDropDown(suppId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}