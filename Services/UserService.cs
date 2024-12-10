using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Domain.Entities;
using Domain.Interfaces.Services;
using Infra.Persistance;
using Infra.Utils;

namespace Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUser(string login)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
    }
    
    public async Task<User> RegisterAsync(string login, string password, string fullName)
    {
        if (await _context.Users.AnyAsync(u => u.Login == login))
        {
            throw new InvalidOperationException("Login já está em uso.");
        }
        
        var user = new User
        {
            Id = Guid.NewGuid(),
            Login = login,
            PasswordHash = PasswordHasher.HashPassword(password),
            FullName = fullName
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }
}