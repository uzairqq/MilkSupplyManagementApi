using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        /// <summary>
        /// Add Supplier
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSupplierRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _supplierService.Post(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Update Supplier 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AddSupplierRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _supplierService.Put(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Delete Supplier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete()]
        public async Task<IActionResult> Delete([FromBody] AddSupplierRequestDto dto)
        {
            try
            {
                return Ok(await _supplierService.Delete(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Get All Supplier
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _supplierService.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Get Supplier By Id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpGet("supplierId/{supplierId}")]
        public async Task<IActionResult> Get([FromRoute] int supplierId)
        {
            try
            {
                return Ok(await _supplierService.GetById(supplierId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> Get([FromRoute] string name)
        {
            try
            {
                return Ok(await _supplierService.IsSupplierNameAvailable(name));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
