using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APIAuth.Models;
using Microsoft.IdentityModel.Tokens;

namespace APIAuth.Services;

public static class TokenService
{
    // Vai retornar o token
    public static string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();   // Variável usada para gerar o token
        var key = Encoding.ASCII.GetBytes(Settings.Secret); // Gera uma key através de um array de bytes

        // Criação do token
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user .Username), // User.Identity.Name
                new Claim(ClaimTypes.Role, user.Role) // User.Identity.IsInRole

            }),
            Expires = DateTime.UtcNow.AddHours(8), // Vida útil do token
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature) // Credencial do token
        };
        // Gerando token
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}