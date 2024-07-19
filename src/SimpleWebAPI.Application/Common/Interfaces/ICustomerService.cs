using SimpleWebAPI.Domain.Customers;

namespace SimpleWebAPI.Application.Common.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomer(Customer customer);
        Task<Customer> GetCustomer(int customerId);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int customerId);
    }
}
