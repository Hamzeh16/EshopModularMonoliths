
namespace Basket;

public static class BasketModule
{
    public static IServiceCollection AddBasketModule(this IServiceCollection services,
       IConfiguration configuration)
    {
        // Add services to the container.
        //services
        // .AddApplictionServices()
        // .AddInfrastructureServices(configuration)
        // .AddApiServices(configuration)

        return services;
    }

    public static IApplicationBuilder UseBasketModule(this IApplicationBuilder app)
    {
        // Configure the HTTP request pipline
        // app
        // .UseApplictionServices()
        // .UseInfrastructureServices()
        // .UseApiServices();

        return app;
    }
}