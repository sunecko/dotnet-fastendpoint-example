using Example.Application.Abstractions;
using Example.Application.Common;
using Example.Application.Common.ResponseModels;
using Example.Application.Mappers;
using Example.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Example.Application.Features.Auth.Login;

public class LoginCommandHandler: BaseCommandHandler<LoginCommand, TokenResponse>
{
    readonly UserManager<User> _userManager;
    readonly ILogger<LoginCommand> _logger;
    readonly ITokenService _tokenService;
    
    public LoginCommandHandler(
        UserManager<User> userManager,
        ILogger<LoginCommand> logger,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _logger = logger;
        _tokenService = tokenService;
    }

    public override async Task<TokenResponse> ExecuteAsync(LoginCommand command, CancellationToken ct = default)
    {
        var user = await _userManager.FindByNameAsync(command.Username);
        if (user is null)
        {
            _logger.LogError($"Username -> {command.Username} does not exist");
            ThrowError("Incorrect user or password", StatusCodes.Status401Unauthorized);
        }

        var result = await _userManager.CheckPasswordAsync(user, command.Password);
        if (!result)
        {
            _logger.LogError($"Password incorrect for user -> {command.Username}");
            ThrowError("Incorrect user or password", StatusCodes.Status401Unauthorized);
        }

        var token = await _tokenService.CreateTokenAsync(user);

        return new TokenResponse { Token = token, UserInfo = user.ToUserDto() };
    }
}