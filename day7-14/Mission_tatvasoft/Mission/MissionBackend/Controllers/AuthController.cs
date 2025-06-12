using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/Login")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IJwtService _jwtService;

    public AuthController(IAuthService authService, IJwtService jwtService)
    {
        _authService = authService;
        _jwtService = jwtService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _authService.AuthenticateAsync(dto.Email, dto.Password);
        if (user == null)
        {
            return Unauthorized(new LoginResponse
            {
                Result = 0,
                Message = "Invalid credentials",
                Data = null
            });
        }

        var token = _jwtService.GenerateToken(user);

        return Ok(new LoginResponse
        {
            Result = 1,
            Message = "Login Successfully",
            Data = token
        });
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var user = await _authService.RegisterAsync(dto);
        if (user == null)
        {
            return BadRequest(new LoginResponse
            {
                Result = 0,
                Message = "User already exists",
                Data = null
            });
        }


        return Ok(new LoginResponse
        {
            Result = 1,
            Message = "",
            Data ="user registered successfully"
        });
    }
}
