using FluentValidation;
using SimpleWebAPI.Domain.Customers;

namespace SimpleWebAPI.Application.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty();
            RuleFor(customer => customer.Surname).NotEmpty();
            RuleFor(customer => customer.Email).NotEmpty();
            RuleFor(customer => customer.MobileNumber).NotEmpty();
        }
    }
}
