using Example.Application.Common;
using Example.Application.Mappers;
using FastEndpoints;
using Microsoft.Extensions.Logging;

namespace Example.Application.Features.Product.Command.Create;

public class CreateProductCommandHandler: BaseCommandHandler<CreateProductCommand, EmptyResponse>
{
    private readonly ILogger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(
        IContext context,
        ILogger<CreateProductCommandHandler> logger): base(context)
    {
        _logger = logger;
    }

    public override async Task<EmptyResponse> ExecuteAsync(CreateProductCommand command, CancellationToken ct = default)
    {
        var product = command.ToProductEntity();

        await Context.Products.AddAsync(product, ct);

        await Context.SaveChangesAsync(ct);

        return new EmptyResponse();
    }
}