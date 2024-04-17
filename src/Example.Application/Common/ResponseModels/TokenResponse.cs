using Example.Application.Dtos;

namespace Example.Application.Common.ResponseModels;

public record TokenResponse
{
    public string Token { get; set; }
    public UserDto UserInfo { get; set; } 
}