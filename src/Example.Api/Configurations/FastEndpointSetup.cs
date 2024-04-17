using FastEndpoints;

namespace Example.Api.Configurations;

public static class FastEndpointSetup
{
    public static IServiceCollection AddFastEndpointSetup(this IServiceCollection services)
    {
        services.AddFastEndpoints();
        
        return services;
    }
}