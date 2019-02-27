using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkManagement.Domain.Dto;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Services.Services.Interfaces;

namespace MilkManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRatesController : ControllerBase
    {
        private readonly ICustomerRateService _rateService;

        public CustomerRatesController(ICustomerRateService rateService)
        {
            _rateService = rateService;
        }

         [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRatesRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _rateService.AddCustomerRates(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Update Customer Rates
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerRatesRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                return Ok(await _rateService.UpdateCustomerRates(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Get All CustomerRates
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _rateService.GetAllCustomerRates());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Get CustomerRates By CustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("customerId/{customerId}")]
        public async Task<IActionResult> GetById([FromRoute] int customerId)
        {
            try
            {
                return Ok(await _rateService.GetCustomerRatesById(customerId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Get Customer Rates By Customer Rates Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("customerRatesId/{customerRatesId}")]
        public async Task<IActionResult> GetByCustomerRatesId([FromRoute] int customerRatesId)
        {
            try
            {
                return Ok(await _rateService.GetCustomerRatesByCustomerId(customerRatesId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        /// <summary>
        /// Delete Customer Rates Id
        /// </summary>
        /// <param name="customerRatesId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CustomerRatesRequestDto dto)
        {
            try
            {
                return Ok(await _rateService.DeleteCustomerRates(dto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// If Rate Is Assigned to That Customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("isRateAssignedToCustomer/id/{id}")]
        public IActionResult IsRateAssignedToCustomer([FromRoute] int id)
        {
            try
            {
                return Ok(_rateService.IsRateAssignedToCustomer(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("customersForCustomerRatesDropdown")]
        public async Task<IActionResult> GetCustomerRatesDropDown()
        {
            try
            {
                var result=await _rateService.GetCustomerRatesDropDown();
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //[HttpGet("custId/{custId}")]
        //public async Task<IActionResult> GetCurrentRateByCustomerId([FromRoute] int custId)
        //{
        //    try
        //    {
        //        return Ok(await _rateService.GetCurrentRateByCustomerIdDropDown(custId));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
    }
}