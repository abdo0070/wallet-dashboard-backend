using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Wallet.Helpers;
using Wallet.Models;

namespace Wallet.Services
{
    public class TokenService
    {
        private readonly JWTOptions _jwtOpt;
        public TokenService(JWTOptions jWTOptions)
        {
            _jwtOpt = jWTOptions;
        }
        public string TokenGenerate(User user)
        {
            // 1. Make the user claims 
            var userClaims = this.GenerateClaims(user);
            // 2. Generate the Token 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOpt.Key));
            var credintial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtOpt.Issuer,
                audience: _jwtOpt.Audience,
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credintial
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private List<Claim> GenerateClaims(User user)
        {
            // Not Implemented
            var userClaims = new List<Claim>();
            return userClaims;
        }
    }
}
