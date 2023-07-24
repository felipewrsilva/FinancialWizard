using FW.Application.Interfaces;
using FW.Application.Services;
using FW.Infrastructure.Interfaces;
using FW.Infrastructure.Repositories;

namespace FW.API.Configurations;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerService, CustomerService>();
    }
}
