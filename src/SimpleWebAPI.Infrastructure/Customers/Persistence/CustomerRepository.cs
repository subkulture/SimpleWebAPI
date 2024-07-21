using Microsoft.EntityFrameworkCore;
using SimpleWebAPI.Application.Common.Interfaces;
using SimpleWebAPI.Domain.Customers;
using SimpleWebAPI.Infrastructure.Common.Persistence;

namespace SimpleWebAPI.Infrastructure.Customers.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDBContext _CustomerDbContext;
        public CustomerRepository(CustomerDBContext customerDBContext)
        {
            _CustomerDbContext = customerDBContext;
        }

        public async Task CreateCustomer(Customer customer)
        {
            await _CustomerDbContext.Customers.AddAsync(customer);
            await _CustomerDbContext.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _CustomerDbContext.Customers.Where(x => x.Id == id).FirstAsync();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var dbCustomer = await _CustomerDbContext.Customers.Where(x => x.Id == customer.Id).FirstAsync();

            dbCustomer.Email = customer.Email;
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.Surname = customer.Surname;
            dbCustomer.MobileNumber = customer.MobileNumber;

            await _CustomerDbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _CustomerDbContext.Customers.Where(x => x.Id == id).FirstAsync();
            _CustomerDbContext.Customers.Remove(customer);
            await _CustomerDbContext.SaveChangesAsync();

        }

    }
}
