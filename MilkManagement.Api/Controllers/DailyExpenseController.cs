using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkManagement.Domain.Dto.RequestDto;
using MilkManagement.Services.Services.Implementation;

namespace MilkManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyExpenseController : ControllerBase
    {
        private readonly IDailyExpenseService _expenseRatesService;

        public DailyExpenseController(IDailyExpenseService expenseRatesService)
        {
            _expenseRatesService = expenseRatesService;
        }
        /// <summary>
        /// Add ExpenseRate
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpenseRateRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(await _expenseRatesService.Post(dto));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ExpenseRateRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                return Ok(await _expenseRatesService.Put(dto));
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
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ExpenseRateRequestDto dto )
        {
            try
            {
                return Ok(await _expenseRatesService.Delete(dto));
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
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _expenseRatesService.GetAll());
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
        /// <param name="expenseId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("expenseId/{expenseId}/date/{date}")]
        public async Task<IActionResult> GetExpenseByDate([FromRoute] int expenseId, [FromRoute] DateTime date)
        {
            try
            {
                return Ok(await _expenseRatesService.GetExpenseByExpenseIdAndDate(expenseId, date));
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
        /// <param name="expenseId"></param>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        [HttpGet("expenseId/{expenseId}/FromDate/{FromDate}/ToDate/{ToDate}")]
        public async Task<IActionResult> GetExpenseFromAndToDate([FromRoute] int expenseId,
            [FromRoute] DateTime FromDate, [FromRoute] DateTime ToDate)
        {
            try
            {
                return Ok(
                    await _expenseRatesService.GetExpenseByExpenseIdWithToAndFromDate(expenseId, ToDate, FromDate));
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
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetAllByDate([FromRoute] DateTime date)
        {
            try
            {
                return Ok(await _expenseRatesService.GetAllExpenseByDate(date));
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
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet("fromDate/{fromDate}/toDate/{toDate}")]
        public async Task<IActionResult> GetAllByFromAndToDate([FromRoute] DateTime fromDate,
            [FromRoute] DateTime toDate)
        {
            try
            {
                return Ok(await _expenseRatesService.GetAllByToAndFromDate(fromDate, toDate));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}