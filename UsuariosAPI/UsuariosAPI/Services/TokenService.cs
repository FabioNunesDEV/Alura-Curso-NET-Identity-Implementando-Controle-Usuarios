
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services;

public class TokenService
{
    public string GenerateToken(Usuario usuario)
    {
        Claim[] claims = new Claim[] {
            new Claim("username",usuario.UserName),
            new Claim("id",usuario.Id),
            new Claim(ClaimTypes.DateOfBirth,usuario.DataNascimento.ToString()),
            new Claim("loginTimestamp", DateTime.UtcNow.ToString())
        };
        
        // Se a string usada para gerar a chave não tiver pelo menos 33 caracteres, o código irá lançar uma exceção.
        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456789012345678901234567890123"));

        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddMinutes(10),
                    claims: claims,
                    signingCredentials: signingCredentials
                   );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}