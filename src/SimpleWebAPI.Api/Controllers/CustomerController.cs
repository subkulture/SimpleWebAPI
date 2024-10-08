using CleanArchitecture.Api.Controllers;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Application.Common.Interfaces;
using SimpleWebAPI.Application.Validators;
using SimpleWebAPI.Contracts.Customer;
using SimpleWebAPI.Domain.Customers;

namespace SimpleWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController(ICustomerService customerService) : ApiController
    {
        private readonly ICustomerService _customerService = customerService;

        [HttpPost()]
        public async Task<IActionResult> PostCustomer(CustomerRequest customerRequest)
        {
            var customerRequestValidator = new CustomerRequestValidator();
            var validationResult = await customerRequestValidator.ValidateAsync(customerRequest);

            if (!validationResult.IsValid)
            {
                List<Error>? errors = validationResult.Errors
                .ConvertAll(error => Error.Validation(
                    code: error.PropertyName,
                    description: error.ErrorMessage));
                return Problem(errors);
            }

            var customer = new Customer()
            {
                Email = customerRequest.Email,
                FirstName = customerRequest.FirstName,
                Surname = customerRequest.Surname,
                MobileNumber = customerRequest.MobileNumber

            };

            await _customerService.CreateCustomer(customer);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var result = await _customerService.GetCustomer(id);

            return result.Match(
                customer => Ok(ToDto(customer)),
                Problem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, CustomerRequest customerRequest)
        {
            var customerRequestValidator = new CustomerRequestValidator();
            var validationResult = await customerRequestValidator.ValidateAsync(customerRequest);

            if (!validationResult.IsValid)
            {
                List<Error>? errors = validationResult.Errors
                .ConvertAll(error => Error.Validation(
                    code: error.PropertyName,
                    description: error.ErrorMessage));
                return Problem(errors);
            }

            var customer = new Customer()
            {
                Id = id,
                Email = customerRequest.Email,
                FirstName = customerRequest.FirstName,
                Surname = customerRequest.Surname,
                MobileNumber = customerRequest.MobileNumber
            };

            await _customerService.UpdateCustomer(customer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);


            return result.Match(
                _ => NoContent(),
                Problem);
        }

        private static CustomerResponse ToDto(Customer customer) =>
        new(customer.Id, customer.FirstName, customer.Surname, customer.Email, customer.MobileNumber);
    }
}
