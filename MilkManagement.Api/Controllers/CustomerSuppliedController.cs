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
    public class CustomerSuppliedController : ControllerBase
    {
        private readonly ICustomerSupplied _customerSupplied;

        public CustomerSuppliedController(ICustomerSupplied customerSupplied)
        {
            _customerSupplied = customerSupplied;
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(CustomerSuppliedRequestDto dto)
        //{
        //    try
        //    {
        //        return await _customerSupplied.
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
    }
}