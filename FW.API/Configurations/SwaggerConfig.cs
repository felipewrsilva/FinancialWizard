using Microsoft.OpenApi.Models;
using System.Reflection;

namespace FW.API.Configurations;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        services.AddSwaggerGen(c =>
        {
            c.IncludeXmlComments(xmlPath);
            c.SwaggerDoc("v1", CreateSwaggerDocInfo());
        });
    }

    private static OpenApiInfo CreateSwaggerDocInfo()
    {
        OpenApiInfo openApiInfo = new()
        {
            Title = "Financial Wizard",
            Version = "v1",
            Contact = new OpenApiContact
            {
                Name = "Felipe Silva",
                Email = "felipewrsilva@gmail.com",
                Url = new Uri("https://github.com/felipewrsilva")
            },
            TermsOfService = new Uri("https://opensource.org/osd"),
        };
        return openApiInfo;
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FW.API v1"));
    }
}
