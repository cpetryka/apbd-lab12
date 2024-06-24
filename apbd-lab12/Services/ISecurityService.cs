using apbd_lab12.Models.Dto;
using apbd_lab12.Models.Security;

namespace apbd_lab12.Services;

public interface ISecurityService
{
    Task<AuthorizationResultDto> RegisterAsync(RegisterOrLoginUserDto registerOrLoginUserDto);
    Task<AuthorizationResultDto> LoginAsync(RegisterOrLoginUserDto registerOrLoginUserDto);
    Task<AuthorizationResultDto> RefreshTokenAsync(string refreshToken);
}