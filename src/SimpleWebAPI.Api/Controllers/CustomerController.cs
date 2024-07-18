using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Application.Common.Interfaces;

namespace SimpleWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost()]
        public async Task<IActionResult> PostCustomer()
        {
            var result = await _customerService.CreateCustomer();

            return Ok();
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var result = await _customerService.GetCustomer(id);

            return Ok();
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> PutCustomer(int id)
        {
            var result = await _customerService.UpdateCustomer(id);

            return Ok();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);

            return Ok();
        }
    }
}
