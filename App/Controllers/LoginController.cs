using Domain.DTOs.Login;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IAuthService _authService;

    public LoginController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var loginResponse = await _authService.Authenticate(loginRequest.Login, loginRequest.Password);

        if (loginResponse == null)
            return Unauthorized(new { Message = "Credenciais inválidas." });
        
        Response.Cookies.Append("token", loginResponse.Token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddHours(1)
        });

        return Ok(new { Message = "Login realizado com sucesso.", Token = loginResponse.Token, User = loginResponse.FullName });
    }

    [HttpPost]
    [Route("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return Ok(new { Message = "Logout realizado com sucesso." });
    }
}