using Example.Application.Common.ResponseModels;
using Example.Application.Features.Auth.Login;
using FastEndpoints;

namespace Example.Api.Endpoints.Auth;

public class LoginEndpoint: Endpoint<LoginCommand, TokenResponse>
{
    public override void Configure()
    {
        Post("/auth/login");
        AllowAnonymous();
        Summary(x => x.Summary = "Get auth token");
    }

    public override async Task HandleAsync(LoginCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response, statusCode: StatusCodes.Status200OK);
    }
}