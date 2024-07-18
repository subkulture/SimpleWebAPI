namespace SimpleWebAPI.Application.Common.Interfaces
{
    public interface ICustomerService
    {
        Task<int> CreateCustomer();
        Task<int> GetCustomer(int customerId);
        Task<int> UpdateCustomer(int customerId);
        Task<int> DeleteCustomer(int customerId);
    }
}
