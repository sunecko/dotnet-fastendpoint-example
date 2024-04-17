using Example.Application.Abstractions;
using Example.Application.Common;
using Example.Application.Common.ResponseModels;
using Example.Application.Mappers;
using Example.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Example.Application.Features.Auth.Register;

public class RegisterCommandHandler: BaseCommandHandler<RegisterCommand, TokenResponse>
{
    readonly UserManager<User> _userManager;
    readonly ILogger<RegisterCommandHandler> _logger;
    private readonly ITokenService _tokenService;

    public RegisterCommandHandler(
        IContext context,
        UserManager<User> userManager,
        ILogger<RegisterCommandHandler> logger,
        ITokenService tokenService): base(context)
    {
        _userManager = userManager;
        _logger = logger;
        _tokenService = tokenService;
    }

    public override async Task<TokenResponse> ExecuteAsync(RegisterCommand command, CancellationToken ct = default)
    {
        var userToRegister = command.ToUserEntity();

        var result = await _userManager.CreateAsync(userToRegister, command.Password);
        foreach (var error in result.Errors)
        {
            _logger.LogError($"Error in register -> {error.Description}");
            AddError($"{error.Description}");
        }
        
        ThrowIfAnyErrors(StatusCodes.Status400BadRequest);

        await Context.SaveChangesAsync(ct);
        
        var user = await _userManager.FindByNameAsync(command.UserName);

        var token = await _tokenService.CreateTokenAsync(user);

        return new TokenResponse { Token = token, UserInfo = user.ToUserDto() };
    }
}