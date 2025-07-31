using BlogApi.Application.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Infrastructure.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;

    public AuthController(IAuthService auth)
    {
        _auth = auth;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var result = await _auth.RegisterAsync(request.Username, request.Password);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserRequest request)
    {
        var result = await _auth.LoginAsync(request.Username, request.Password);
        return Ok(result);
    }
}
