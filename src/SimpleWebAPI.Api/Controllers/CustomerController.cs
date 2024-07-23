using CleanArchitecture.Api.Controllers;
using ErrorOr;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Application.Common.Interfaces;
using SimpleWebAPI.Application.Validators;
using SimpleWebAPI.Contracts.Customer;
using SimpleWebAPI.Domain.Customers;

namespace SimpleWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost()]
        public async Task<IActionResult> PostCustomer(CustomerRequest customerRequest)
        {
            var customerRequestValidator = new CustomerRequestValidator();

            ValidationResult? validationResult = await customerRequestValidator.ValidateAsync(customerRequest);

            List<Error>? errors = validationResult.Errors
            .ConvertAll(error => Error.Validation(
                code: error.PropertyName,
                description: error.ErrorMessage));

            if (!validationResult.IsValid)
            {
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
            await _customerService.DeleteCustomer(id);

            return NoContent();
        }

        private CustomerResponse ToDto(Customer customer) =>
        new(customer.Id, customer.FirstName, customer.Surname, customer.Email, customer.MobileNumber);
    }
}
