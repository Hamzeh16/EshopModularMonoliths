using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shared.Behavires;
using System.Reflection;

namespace Shared.Extentions;

public static class MediatRExtentions
{
    public static IServiceCollection AddMediatRWithAssemblies
    (this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(assemblies);
            config.AddOpenBehavior(typeof(ValidtionBehavires<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddValidatorsFromAssemblies(assemblies);

        return services;
    }
}
