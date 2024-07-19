using Microsoft.EntityFrameworkCore;
using SimpleWebAPI.Domain.Customers;


namespace SimpleWebAPI.Infrastructure.Common.Persistence
{
    public class CustomerDBContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}