using Example.Application.Common.ResponseModels;
using FastEndpoints;

namespace Example.Application.Features.Auth.Register;

public record RegisterCommand: ICommand<TokenResponse>
{
    public string UserName { get; set; }
    
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    public string LastName { get; set; }
    
    public string Password { get; set; }
}