using Example.Domain.Entities.Identity;

namespace Example.Application.Abstractions;

public interface ITokenService
{
    public Task<string> CreateTokenAsync(User user);
}