using Microsoft.Extensions.DependencyInjection;
using SimpleWebAPI.Application.Common.Interfaces;
using SimpleWebAPI.Infrastructure.Customer.Persistence;

namespace SimpleWebAPI.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
