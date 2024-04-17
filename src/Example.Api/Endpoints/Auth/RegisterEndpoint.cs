using Example.Application.Common.ResponseModels;
using Example.Application.Features.Auth.Login;
using Example.Application.Features.Auth.Register;
using FastEndpoints;

namespace Example.Api.Endpoints.Auth;

public class RegisterEndpoint: Endpoint<RegisterCommand, TokenResponse>
{
    public override void Configure()
    {
        Post("/auth/register");
        AllowAnonymous();
        Summary(x => x.Summary = "Register a new user");
    }

    public override async Task HandleAsync(RegisterCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response, statusCode: StatusCodes.Status201Created);
    }
}