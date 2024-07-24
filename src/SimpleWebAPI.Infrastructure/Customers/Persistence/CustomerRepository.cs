using ErrorOr;
using Microsoft.EntityFrameworkCore;
using SimpleWebAPI.Application.Common.Interfaces;
using SimpleWebAPI.Domain.Customers;
using SimpleWebAPI.Infrastructure.Common.Persistence;

namespace SimpleWebAPI.Infrastructure.Customers.Persistence
{
    public class CustomerRepository(CustomerDBContext customerDBContext) : ICustomerRepository
    {
        private readonly CustomerDBContext _CustomerDbContext = customerDBContext;

        public async Task CreateCustomer(Customer customer)
        {
            await _CustomerDbContext.Customers.AddAsync(customer);
            await _CustomerDbContext.SaveChangesAsync();
        }

        public async Task<ErrorOr<Customer>> GetCustomer(int id)
        {
            var customer = await _CustomerDbContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (customer == null)
            {
                return Error.NotFound(description: "Customer not found");
            }

            return customer;
        }

        public async Task<ErrorOr<Updated>> UpdateCustomer(Customer customer)
        {
            var dbCustomer = await _CustomerDbContext.Customers.Where(x => x.Id == customer.Id).FirstOrDefaultAsync();

            if (dbCustomer == null)
            {
                return Error.NotFound(description: "Customer not found");
            }

            dbCustomer.Email = customer.Email;
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.Surname = customer.Surname;
            dbCustomer.MobileNumber = customer.MobileNumber;

            await _CustomerDbContext.SaveChangesAsync();

            return Result.Updated;
        }

        public async Task<ErrorOr<Deleted>> DeleteCustomer(int id)
        {
            var customer = await _CustomerDbContext.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (customer == null)
            {
                return Error.NotFound(description: "Customer not found");
            }

            _CustomerDbContext.Customers.Remove(customer);
            await _CustomerDbContext.SaveChangesAsync();

            return Result.Deleted;
        }

    }
}
