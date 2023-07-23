using FW.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FW.API.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FWDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void UseDatabaseConfiguration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<FWDbContext>();
        context?.Database.Migrate();
        context?.Database.EnsureCreated();
    }
}
