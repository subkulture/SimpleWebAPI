using SimpleWebAPI.Application.Common.Interfaces;

namespace SimpleWebAPI.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<int> CreateCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
