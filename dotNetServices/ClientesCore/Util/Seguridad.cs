using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClientesCore.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ClientesCore.Util
{
    public class Seguridad
    {
        public static string CrearJwt(ClienteEntity cliente)
        {
            // Leemos el secret_key desde nuestro appseting
            var secretKey = "asdwda1d8a4sd8w4das8d*w8d*asd@#";
            var key = Encoding.ASCII.GetBytes(secretKey);

            // Creamos los claims (pertenencias, características) del usuario
            var claims = new[]
            {
                        new Claim(ClaimTypes.NameIdentifier, cliente.IdCliente.ToString())
                    };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
