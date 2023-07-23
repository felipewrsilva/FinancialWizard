using FW.API.Middleware;

namespace FW.API.Configurations;

public static class GlobalExceptionHandlingConfig
{
    public static void AddGlobalExceptionHandlingConfiguration(this IServiceCollection services)
    {
        services.AddTransient<GlobalExceptionHandlingMiddleware>();
    }

    public static void UseGlobalExceptionHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
    }
}
