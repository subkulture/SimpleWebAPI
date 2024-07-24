using ErrorOr;
using SimpleWebAPI.Domain.Customers;

namespace SimpleWebAPI.Application.Common.Interfaces
{
    public interface ICustomerRepository
    {
        public Task CreateCustomer(Customer customer);
        public Task<ErrorOr<Customer>> GetCustomer(int id);
        public Task<ErrorOr<Updated>> UpdateCustomer(Customer customer);
        public Task<ErrorOr<Deleted>> DeleteCustomer(int id);
    }
}
