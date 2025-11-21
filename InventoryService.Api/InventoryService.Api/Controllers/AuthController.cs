using Microsoft.AspNetCore.Mvc;
using InventoryService.Api.Auth;

namespace InventoryService.Api.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    public AuthController(IAuthService auth) => _auth = auth;

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest req)
    {
        var token = _auth.Authenticate(req.Username, req.Password);
        return token == null ? Unauthorized() : Ok(new { token });
    }
}

public record LoginRequest(string Username, string Password);
