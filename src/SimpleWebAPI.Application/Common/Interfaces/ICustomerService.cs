using ErrorOr;
using SimpleWebAPI.Domain.Customers;

namespace SimpleWebAPI.Application.Common.Interfaces
{
    public interface ICustomerService
    {
        Task<ErrorOr<Created>> CreateCustomer(Customer customer);
        Task<ErrorOr<Customer>> GetCustomer(int customerId);
        Task<ErrorOr<Updated>> UpdateCustomer(Customer customer);
        Task<ErrorOr<Deleted>> DeleteCustomer(int customerId);
    }
}
