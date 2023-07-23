using FW.API.Middleware;
using FW.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FW.API.Configurations;

public static class ExceptionHandlingConfig
{
    public static void AddGlobalExceptionHandlingConfiguration(this IServiceCollection services)
    {
        services.AddGlobalExceptionHandlingConfiguration();
    }

    public static void ExceptionHandlingConfiguration(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    }
}
