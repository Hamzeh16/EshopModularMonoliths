using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.Data;
using Shared.Data.Interceptor;

namespace Basket;

public static class BasketModule
{
    public static IServiceCollection AddBasketModule(this IServiceCollection services,
       IConfiguration configuration)
    {
        // Add services to the container.

        // 1. Api Endpoint services

        // 2. Application Use Case services
        services.AddScoped<IBasketRepossitory, BasketRepossitory>();
        services.Decorate<IBasketRepossitory, CachedBasketRepossitory>();

        // Data - Infrastructure services
        var connectionString = configuration.GetConnectionString("Database");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();


        services.AddDbContext<BasketDbContext>((sp, option) =>
        {
            option.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            option.UseNpgsql(connectionString);
        });

        return services;
    }

    public static IApplicationBuilder UseBasketModule(this IApplicationBuilder app)
    {
        // Configure the HTTP request pipeline.
        // 1. Use Api Endpoint services

        // 2. Use Application Use Case services

        // 3. Use Data - Infrastructure services
        app.UseMigration<BasketDbContext>();

        return app;

    }
}