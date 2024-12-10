using System.Security.Claims;
using Domain.DTOs.TimeKeeping;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TimeKeepingController : ControllerBase
{
    private readonly ITimeKeepingService _timeKeepingService;

    public TimeKeepingController(ITimeKeepingService timeKeepingService)
    {
        _timeKeepingService = timeKeepingService;
    }

    [HttpPost("timeRegister")]
    public IActionResult RegisterTime([FromBody] TimeKeepingRequestDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        
        if (userIdClaim == null)
            return Unauthorized("Token inválido ou não encontrado.");
        
        var userId = Guid.Parse(userIdClaim.Value);

        var result = _timeKeepingService.RegisterTime(userId, request);

        if (!result.Success)
            return Problem("Ocorreu um erro ao registrar o ponto");

        return Ok(new { Message = "Ponto registrado com sucesso." });
    }

    [HttpGet("history")]
    public IActionResult GetHistory([FromQuery] int? month, [FromQuery] int? year)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        
        if (userIdClaim == null)
            return Unauthorized("Token inválido ou não encontrado.");
        
        var userId = Guid.Parse(userIdClaim.Value);

        var result = _timeKeepingService.GetTimeHistory(userId, month, year);
        return Ok(result);
    }
}