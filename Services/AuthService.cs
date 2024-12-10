using Domain.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.DTOs.Login;
using Infra.Persistance;
using Infra.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Services;

public class AuthService : IAuthService
{
    private readonly string _jwtKey;
    
    private readonly AppDbContext _dbContext;
    private readonly IUserService _userService;
    
    public AuthService(AppDbContext dbContext, IUserService userService, IConfiguration config)
    {
        _dbContext = dbContext;
        _userService = userService;
        _jwtKey = config["Jwt:Key"];
    }

    public async Task<LoginResponseDto?> Authenticate(string username, string password)
    {
        var user = await _userService.GetUser(username);

        if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordHash))
            return null;
        
        var tokenHandler = new JwtSecurityTokenHandler();
        
        var claims = new List<Claim>
        {
            new Claim("sub", user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new LoginResponseDto()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            FullName = user.FullName,
        };
    }
}