using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerServices;

        public CustomerController(ICustomerService customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _customerServices.GetAllAsync());
            }
            catch (Exception e)
            {
                    Console.WriteLine(e);
                    throw;
            }
        }
    }
}