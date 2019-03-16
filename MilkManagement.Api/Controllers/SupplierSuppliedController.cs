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
        public async Task<IActionResult> Get([FromRoute] DateTime date)
        {
            try
            {
                return Ok(await _supplierSuppliedServices.Get(date));
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

        [HttpGet("supplierSuppliedDropDown")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _supplierSuppliedServices.Get();
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