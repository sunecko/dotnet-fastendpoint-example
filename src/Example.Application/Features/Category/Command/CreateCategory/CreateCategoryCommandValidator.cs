using Example.Application.Features.Category.CreateCategory;
using FastEndpoints;
using FluentValidation;

namespace Example.Application.Features.Category.Command.CreateCategory;

public class CreateCategoryCommandValidator: Validator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(100)
            .WithMessage("Description must not exceed 250 characters");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Description is required")
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters");
        
        RuleFor(x => x.ImageUrl)
            .NotEmpty()
            .NotNull()
            .WithMessage("ImageUrl is required")
            .MaximumLength(250)
            .WithMessage("ImageUrl must not exceed 250 characters");
    }
}