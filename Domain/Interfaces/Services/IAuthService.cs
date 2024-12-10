using Domain.DTOs.Login;

namespace Domain.Interfaces.Services;

public interface IAuthService
{
    Task<LoginResponseDto?> Authenticate(string username, string password);
}