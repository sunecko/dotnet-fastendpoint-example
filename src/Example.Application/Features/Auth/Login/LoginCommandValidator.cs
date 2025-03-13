using FastEndpoints;
using FluentValidation;

namespace Example.Application.Features.Auth.Login;

public class LoginCommandValidator: Validator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .NotNull();
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull();
    }
}