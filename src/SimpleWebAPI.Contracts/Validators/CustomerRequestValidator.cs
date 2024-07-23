using FluentValidation;
using SimpleWebAPI.Contracts.Customer;

namespace SimpleWebAPI.Application.Validators
{
    public class CustomerRequestValidator : AbstractValidator<CustomerRequest>
    {
        public CustomerRequestValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty();
            RuleFor(customer => customer.Surname).NotEmpty();
            RuleFor(customer => customer.Email).NotEmpty();
            RuleFor(customer => customer.MobileNumber).NotEmpty();
        }
    }
}
