using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Application.Common.Interfaces;
using SimpleWebAPI.Domain.Customers;

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
            await _customerService.CreateCustomer(new Domain.Customers.Customer());

            return Ok();
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var result = await _customerService.GetCustomer(id);

            return Ok();
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {
            await _customerService.UpdateCustomer(customer);

            return Ok();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomer(id);

            return Ok();
        }
    }
}
