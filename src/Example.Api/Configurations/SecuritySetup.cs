using Example.Application.Configurations;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Example.Api.Configurations;

public static class SecuritySetup
{
    public static IServiceCollection AddSecuritySetup(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TokenSettings>(configuration.GetSection("TokenOptions"));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        });
        services.AddAuthenticationJwtBearer(s => s.SigningKey = configuration["TokenOptions:Key"]);
        return services;
    }
}