using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebAPI.Application.Common.Interfaces;
using SimpleWebAPI.Infrastructure.Common.Persistence;
using SimpleWebAPI.Infrastructure.Customers.Persistence;

namespace SimpleWebAPI.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddDbContext<CustomerDBContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));
            return services;
        }
    }
}
