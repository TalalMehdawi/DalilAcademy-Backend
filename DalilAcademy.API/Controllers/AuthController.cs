using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Service;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DalilAcademy.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginRequsetDto dto)
    {
        return Ok(await authService.Login(dto));
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> Register(RegisterRequsetDto dto)
    {
        return Ok(await authService.Register(dto));
    }
}