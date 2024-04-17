using FastEndpoints;
using TokenResponse = Example.Application.Common.ResponseModels.TokenResponse;

namespace Example.Application.Features.Auth.Login;

public record LoginCommand: ICommand<TokenResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}