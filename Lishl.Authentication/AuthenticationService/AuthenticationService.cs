using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Lishl.Authentication.Core.Configurations;
using Lishl.Authentication.Responses;
using Lishl.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace Lishl.Authentication.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenConfiguration _tokenConfiguration;

        public AuthenticationService(ITokenConfiguration tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration;
        }
        
        public AuthResponse Authenticate(User user)
        {
            var token = GenerateToken(user);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponse
            {
                UserId = user.Id,
                ExpiresIn = token.ValidTo,
                Token = tokenString
            };
        }

        private JwtSecurityToken GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.ToString())));

            return new JwtSecurityToken(
                _tokenConfiguration.Issuer,
                _tokenConfiguration.Audience,
                claims,
                expires: DateTime.Now.AddDays(_tokenConfiguration.TokenExpires),
                signingCredentials: credentials);
        }
    }
}