using ErrorOr;
using SimpleWebAPI.Application.Common.Interfaces;
using SimpleWebAPI.Domain.Customers;

namespace SimpleWebAPI.Application.Services
{
    public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task CreateCustomer(Customer customer)
        {
            await _customerRepository.CreateCustomer(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            await _customerRepository.DeleteCustomer(id);
        }

        public async Task<ErrorOr<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepository.GetCustomer(id);

            if (customer is null)
            {
                return Error.NotFound(description: "Customer not found");
            }

            return customer;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _customerRepository.UpdateCustomer(customer);
        }
    }
}
