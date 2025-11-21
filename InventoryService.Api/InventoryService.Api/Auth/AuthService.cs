using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace InventoryService.Api.Auth;

public interface IAuthService 
{
    string? Authenticate(string username, string password);
}

public class AuthService : IAuthService
{
    private readonly JwtSettings _jwt;
    private readonly Dictionary<string, string> _users = new()
    {
        {"admin","Password123!"},
        {"user","Password123!"}
    };

    public AuthService(JwtSettings jwt) => _jwt = jwt;

    public string? Authenticate(string username, string password)
    {
        if (!_users.TryGetValue(username, out var pwd) || pwd != password) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwt.SecretKey);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, username=="admin"?"Admin":"User")
        };

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwt.ExpiresInMinutes),
            Issuer = _jwt.Issuer,
            Audience = _jwt.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                        SecurityAlgorithms.HmacSha256)
        });

        return tokenHandler.WriteToken(token);
    }
}
