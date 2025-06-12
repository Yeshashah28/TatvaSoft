using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using BookApi.Data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly JWTServices _jwtService;

    public AuthController(AppDbContext context, JWTServices jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User request)
    {
        if (await _context.Users.AnyAsync(u => u.Username == request.Username))
            return BadRequest("Username already exists");

        var user = new User
        {
            Username = request.Username,
            Password=request.Password,
            Role = request.Role,
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User registered successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
        if (user == null) return Unauthorized("Invalid username or password");

        if (request.Password!=user.Password)
            return Unauthorized("Invalid username or password");

        var token = _jwtService.GenerateToken(user);

        return Ok(new { Token = token });
    }
 
}
