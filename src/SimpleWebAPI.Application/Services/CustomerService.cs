using ErrorOr;
using SimpleWebAPI.Application.Common.Interfaces;
using SimpleWebAPI.Domain.Customers;

namespace SimpleWebAPI.Application.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<ErrorOr<Created>> CreateCustomer(Customer customer)
        {
            await _customerRepository.CreateCustomer(customer);

            return Result.Created;
        }

        public async Task<ErrorOr<Deleted>> DeleteCustomer(int id)
        {
            var result = await _customerRepository.DeleteCustomer(id);

            if (result.IsError)
            {
                return result.Errors;
            }

            return Result.Deleted;
        }

        public async Task<ErrorOr<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomer(id);

            return customer;
        }

        public async Task<ErrorOr<Updated>> UpdateCustomer(Customer customer)
        {
            await _customerRepository.UpdateCustomer(customer);

            return Result.Updated;
        }
    }
}
