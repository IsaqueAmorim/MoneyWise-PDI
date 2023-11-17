using Microsoft.IdentityModel.Tokens;
using MoneyWise.Dominio.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoneyWise.Servico.Autenticacao
{
    public class GeradorDeToken
    {
        public static string GerarToken(Usuario usuario)
        {
            var chaveSecreta = Environment.GetEnvironmentVariable("JWT_SECRET");

            if (string.IsNullOrEmpty(chaveSecreta))
                throw new Exception("Variável de ambiente [JWT_SECRET] inválida.");

            var tokenHandler = new JwtSecurityTokenHandler();

            var dadosDoToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(chaveSecreta)), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(dadosDoToken);
            return tokenHandler.WriteToken(token);
        }
    }
}
