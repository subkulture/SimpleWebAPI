using SimpleWebAPI.Domain.Customers;

namespace SimpleWebAPI.Application.Common.Interfaces
{
    public interface ICustomerRepository
    {
        public Task CreateCustomer(Customer customer);
        public Task<Customer?> GetCustomer(int id);
        public Task UpdateCustomer(Customer customer);
        public Task DeleteCustomer(int id);
    }
}
