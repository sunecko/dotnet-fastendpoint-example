using Example.Application.Dtos;
using Example.Application.Features.Product.Command.Create;
using Example.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Example.Application.Mappers;

[Mapper]
public static partial class ProductMapper
{
    public static partial Product ToProductEntity(this CreateProductCommand source);

    public static partial ProductDto ToProductDto(this Product source);
}