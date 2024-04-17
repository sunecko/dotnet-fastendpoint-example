using Example.Application.Abstractions;
using Example.Application.Common;
using Example.Application.Services;
using Example.Infrastructure;

namespace Example.Api.Configurations;

public static class ApplicationSetup
{
    public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
    {
        services.AddScoped<IContext, ApplicationDbContext>();
        services.AddScoped<ITokenService, TokenService>();
        
        return services;
    }
}