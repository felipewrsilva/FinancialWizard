using FW.API.Profiles.Entities;
using FW.Domain.StrongTyped;

namespace FW.API.Configurations;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(CustomerProfile),
            typeof(CustomerId));
    }
}
