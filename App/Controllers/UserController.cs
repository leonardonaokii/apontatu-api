using Domain.DTOs.User;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("user")]
    public async Task<User> User([FromBody] RegisterUserDto userDto)
    {
        var user = await _userService.RegisterAsync(userDto.Login, userDto.Password, userDto.FullName);
        
        return user;
    }
}