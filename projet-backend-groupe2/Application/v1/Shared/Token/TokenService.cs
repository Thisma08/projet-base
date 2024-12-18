using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Application.v1.Cores.Users.Commands.Login;
using Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.v1.Shared.Token;

public class TokenService
{
    // TODO : a changée
    // public const double ExpiryDurationMinutes = 30; // 30 minutes 
    public const double ExpiryDurationMinutes = 1440; // = 1 Days 

    private const string IdKey = "Id";
    private const string UsernameKey = "Username";
    private const string RoleKey = "Role";
    private readonly string _issuer;

    private readonly string _key;

    public TokenService(IConfiguration configuration)
    {
        _key = configuration["Jwt:Key"]!;
        _issuer = configuration["Jwt:Issuer"]!;
    }

    public string BuildToken(UsersLoginOutput user)
    {
        var claims = new[]
        {
            new Claim(IdKey, user.Id.ToString()),
            new Claim(UsernameKey, user.Username),
            new Claim(RoleKey, user.Role),
            new Claim(ClaimTypes.NameIdentifier,
                Guid.NewGuid().ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(
            _issuer,
            _issuer,
            claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.Now.AddMinutes(ExpiryDurationMinutes),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    public bool IsTokenValid(string? token)
    {
        var mySecret = Encoding.UTF8.GetBytes(_key);
        var mySecurityKey = new SymmetricSecurityKey(mySecret);
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _issuer,
                    ValidAudience = _issuer,
                    IssuerSigningKey = mySecurityKey,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);
        }
        catch
        {
            return false;
        }

        return true;
    }

    public int GetId(string? token)
    {
        if (!IsTokenValid(token)) return 0;

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        return Convert.ToInt32(jwtToken.Claims.First(c => c.Type == IdKey).Value.ToString());
    }

    public string? GetUsername(string? token)
    {
        if (!IsTokenValid(token)) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        return jwtToken.Claims.First(c => c.Type == UsernameKey).Value.ToString();
    }

    public string? GetRole(string? token)
    {
        if (!IsTokenValid(token)) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        return jwtToken.Claims.First(c => c.Type == RoleKey).Value.ToString();
    }

    public bool IsAdmin(string token)
    {
        return GetRole(token)!.Equals("ROLES_ADMIN");
    }

    public bool IsTheRightUser(string token)
    {
        return GetRole(token)!.Equals("ROLES_ADMIN");
    }
}