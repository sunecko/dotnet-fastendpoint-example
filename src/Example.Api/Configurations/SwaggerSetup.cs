using FastEndpoints.Swagger;
namespace Example.Api.Configurations;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwaggerSetup(this IServiceCollection services)
    {
        services.SwaggerDocument(o =>
        {
            o.DocumentSettings = s =>
            {
                s.Title = "Example API";
                s.Version = "v1";
            };
        });

        return services;
    }
}