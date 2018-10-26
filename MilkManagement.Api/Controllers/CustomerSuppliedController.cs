using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Domain.Dto.ResponseDto;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSuppliedController : ControllerBase
    {
        private readonly ICustomerSuppliedService _customerSuppliedService;

        public CustomerSuppliedController(ICustomerSuppliedService customerSuppliedService)
        {
            _customerSuppliedService = customerSuppliedService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerSuppliedRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _customerSuppliedService.Post(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(CustomerSuppliedRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _customerSuppliedService.Put(dto));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _customerSuppliedService.Get());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpGet("allCustomerSuppliedByDate")]
        public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByDate(DateTime date)
        {
            try
            {
                var customerSupplied = await _customerSuppliedService.GetCustomerSuppliedByDate(date);
                return customerSupplied;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}