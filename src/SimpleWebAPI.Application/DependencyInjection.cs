using Microsoft.Extensions.DependencyInjection;
using SimpleWebAPI.Application.Common.Interfaces;
using SimpleWebAPI.Application.Services;

namespace SimpleWebAPI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();

        return services;
    }
}