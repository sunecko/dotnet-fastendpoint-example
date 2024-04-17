using FastEndpoints;

namespace Example.Application.Features.Product.Command.Create;

public record CreateProductCommand : ICommand<EmptyResponse>
{
    public string Name { get; init; }
    
    public string Description { get; init; }
    
    public string ImageUrl { get; init; }
    
    public decimal Price { get; init; }
    
    public long CategoryId { get; init; }
}