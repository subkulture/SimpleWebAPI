using SimpleWebAPI.Application.Common.Interfaces;
using SimpleWebAPI.Domain.Customers;

namespace SimpleWebAPI.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateCustomer(Customer customer)
        {
            await _customerRepository.CreateCustomer(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            await _customerRepository.DeleteCustomer(id);
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _customerRepository.GetCustomer(id);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _customerRepository.UpdateCustomer(customer);
        }
    }
}
