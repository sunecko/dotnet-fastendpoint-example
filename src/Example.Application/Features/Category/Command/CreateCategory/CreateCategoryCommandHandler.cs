using Example.Application.Common;
using Example.Application.Features.Category.CreateCategory;
using Example.Application.Mappers;
using FastEndpoints;
using Microsoft.Extensions.Logging;

namespace Example.Application.Features.Category.Command.CreateCategory;

public class CreateCategoryCommandHandler: BaseCommandHandler<CreateCategoryCommand, EmptyResponse>
{
    private readonly ILogger<CreateCategoryCommandHandler> _logger;
    
    public CreateCategoryCommandHandler(
        IContext context,
        ILogger<CreateCategoryCommandHandler> logger) : base(context)
    {
        _logger = logger;
    }

    public override async Task<EmptyResponse> ExecuteAsync(CreateCategoryCommand command, CancellationToken ct)
    {
        var category = command.ToCategoryEntity();
        
        await Context.Categories.AddAsync(category, ct);

        await Context.SaveChangesAsync(ct);
        
        _logger.LogInformation("Category created successfully.");
        return new EmptyResponse();
    }
}