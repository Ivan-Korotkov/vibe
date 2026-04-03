using Infrastructure.Data.DataBaseContext;
using Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiSrvices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddOpenApi();

        return services;
    }

    public static WebApplication UseApiServices(
        this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
