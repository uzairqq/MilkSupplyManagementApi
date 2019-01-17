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

        //[HttpPost]
        //public async Task<IActionResult> Post(CustomerSuppliedRequestDto dto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return BadRequest(ModelState);
        //        return Ok(await _customerSuppliedService.Post(dto));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

        //[HttpPut]
        //public async Task<IActionResult> Put(CustomerSuppliedRequestDto dto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid) return BadRequest(ModelState);
        //        return Ok(await _customerSuppliedService.Put(dto));

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

        //[HttpGet("all")]
        //public async Task<IActionResult> Get()
        //{
        //    try
        //    {
        //        return Ok(await _customerSuppliedService.Get());
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        //[HttpGet("all/currentDate/{date}")]
        //public async Task<IEnumerable<CustomerSuppliedResponseDto>> GetCustomerSuppliedByDate(DateTime date)
        //{
        //    try
        //    {
        //        var customerSupplied = await _customerSuppliedService.GetCustomerSuppliedByDate(date);
        //        return customerSupplied;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        //[HttpGet("customerId/{customerId}")]
        //public async Task<IActionResult> GetByCustomerId([FromRoute] int customerId)
        //{
        //    try
        //    {
        //        return Ok(await _customerSuppliedService.GetCustomerSuppliedByCustomerId(customerId));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        //[HttpGet("customerSuppliedId/{customerSuppliedId}")]
        //public async Task<IActionResult> GetByCustomerSuppliedId([FromRoute] int customerSuppliedId)
        //{
        //    try
        //    {
        //        return Ok(await _customerSuppliedService.GetCustomerSuppliedByCustomerSuppliedId(customerSuppliedId));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        //[HttpGet("all/startDate/{startDate}/endDate/{endDate}")]
        //public async Task<IActionResult> GetCustomerByStartEndDate([FromRoute] DateTime startDate,
        //   [FromRoute] DateTime endDate)
        //{
        //    try
        //    {
        //        return Ok(await _customerSuppliedService.GetCustomerSuppliedByStartAndEndDate(startDate, endDate));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}

       // [HttpGet("customerId/{customerId}/date/{date}")]
       // public async Task<IActionResult> GetCustomerSuppliedByCustomerIdAndDate([FromRoute] int customerId,
       //[FromRoute] DateTime date)
       // {
       //     try
       //     {
       //         return Ok(await _customerSuppliedService.GetCustomerSuppliedByCustomerIdAndParticularDate(customerId, date));
       //     }
       //     catch (Exception e)
       //     {
       //         Console.WriteLine(e);
       //         throw;
       //     }
       // }

        //[HttpGet("customerId/{customerId}/startDate/{startDate}/endDate/{endDate}")]
        //public async Task<IActionResult> GetCustomerSuppliedByCustomerIdStartDateAndEndDate([FromRoute] int customerId,
        //DateTime startDate, DateTime endDate)
        //{
        //    try
        //    {
        //        return Ok(await _customerSuppliedService.GetCustomerSuppliedByCustomerIdStartDateAndEndDate(customerId,
        //            startDate, endDate));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        //[HttpDelete]
        //public async Task<IActionResult> DeleteCustomerSupplied([FromBody] CustomerSuppliedRequestDto dto)
        //{
        //    try
        //    {
        //        return Ok(await _customerSuppliedService.Delete(dto));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
    }
}