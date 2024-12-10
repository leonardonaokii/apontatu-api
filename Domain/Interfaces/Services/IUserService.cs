using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IUserService
{
    Task<User?> GetUser(string login);
    Task<User> RegisterAsync(string login, string password, string fullName);
}