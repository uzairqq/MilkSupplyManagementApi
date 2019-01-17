//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace MilkManagement.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ExpenseController : ControllerBase
//    {
        
//        public ExpenseController()
//        {
            
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="dto"></param>
//        /// <returns></returns>
//        [HttpPut]
//        public async Task<IActionResult> Put([FromBody] UpdateExpenseRequestDto dto)
//        {
//            try
//            {
//                if (!ModelState.IsValid) return BadRequest();
//                return Ok(await _expenseServices.UpdateExpense(dto));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="expenseId"></param>
//        /// <returns></returns>
//        [HttpDelete("expenseId/{expenseId}")]
//        public async Task<IActionResult> Delete([FromRoute] int expenseId)
//        {
//            try
//            {
//                return Ok(await _expenseServices.DeleteExpense(expenseId));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        [HttpGet("all")]
//        public async Task<IActionResult> Get()
//        {
//            try
//            {
//                return Ok(await _expenseServices.GetAll());
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="expenseId"></param>
//        /// <returns></returns>
//        [HttpGet("expenseId/{expenseId}")]
//        public async Task<IActionResult> GetById([FromRoute] int expenseId)
//        {
//            try
//            {
//                return Ok(await _expenseServices.GetById(expenseId));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="expenseName"></param>
//        /// <returns></returns>
//        [HttpGet("expenseName/{expenseName}")]
//        public async Task<IActionResult> GetByName([FromRoute] string expenseName)
//        {
//            try
//            {
//                return Ok(await _expenseServices.GetByName(expenseName));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="name"></param>
//        /// <returns></returns>
//        [HttpGet("name/{name}")]
//        public async Task<IActionResult> IsExpenseNameAvailable([FromRoute] string name)
//        {
//            try
//            {
//                return Ok(await _expenseServices.IsExpenseNameAvailable(name));
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//    }
//}