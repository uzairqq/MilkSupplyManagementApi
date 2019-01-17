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
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpenseRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                return Ok(await _expenseService.Post(dto));
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
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ExpenseRequestDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();
                return Ok(await _expenseService.UpdateExpense(dto));
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
        /// <returns></returns>
        [HttpDelete("expenseId/{expenseId}")]
        public async Task<IActionResult> Delete([FromBody] ExpenseRequestDto dto )
        {
            try
            {
                return Ok(await _expenseService.DeleteExpense(dto));
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
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _expenseService.GetAll());
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
        /// <returns></returns>
        //[HttpGet("expenseId/{expenseId}")]
        //public async Task<IActionResult> GetById([FromRoute] int expenseId)
        //{
        //    try
        //    {
        //        return Ok(await _expenseService.GetById(expenseId));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expenseName"></param>
        /// <returns></returns>
        //[HttpGet("expenseName/{expenseName}")]
        //public async Task<IActionResult> GetByName([FromRoute] string expenseName)
        //{
        //    try
        //    {
        //        return Ok(await _expenseService.GetByName(expenseName));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("name/{name}")]
        public async Task<IActionResult> IsExpenseNameAvailable([FromRoute] string name)
        {
            try
            {
                return Ok(await _expenseService.IsExpenseNameAvailable(name));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}