using Microsoft.IdentityModel.Tokens;
using RCloud.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RCloud.Providers;
public class JwtProvider
{
        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString()), new("userEmail",user.Email)];
            var token = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
}