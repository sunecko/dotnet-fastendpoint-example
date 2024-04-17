using Example.Application.Abstractions;
using Example.Application.Configurations;
using Example.Domain.Entities.Identity;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Example.Application.Services;

public class TokenService: ITokenService
{
    readonly UserManager<User> _userManager;
    readonly TokenSettings _tokenSettings; 

    public TokenService(UserManager<User> userManager, IOptions<TokenSettings> tokenSettings)
    {
        _userManager = userManager;
        _tokenSettings = tokenSettings.Value;
    }

    public async Task<string> CreateTokenAsync(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var token = JwtBearer.CreateToken(o =>
        {
            o.Audience = _tokenSettings.Audience;
            o.Audience = _tokenSettings.Issuer;
            o.SigningKey = _tokenSettings.Key;
            o.ExpireAt = DateTime.UtcNow.AddDays(_tokenSettings.Expiration);
            o.User.Roles.AddRange(roles);
            o.User.Claims
                .Add(("UserName", user.Name),
                    ("Email", user.Email!));
            o.User["UserId"] = user.Id.ToString();
        });

        return token;
    }
}