using Example.Application.Dtos;
using Example.Application.Features.Auth.Register;
using Example.Domain.Entities.Identity;
using Riok.Mapperly.Abstractions;

namespace Example.Application.Mappers;

[Mapper]
public static partial class UserMapper
{
    public static partial UserDto ToUserDto(this User source);
    public static partial User ToUserEntity(this RegisterCommand source);
}