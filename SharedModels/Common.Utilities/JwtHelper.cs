using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedModels;

namespace Common.Utilities
{
    public   class JwtHelper  : Common.Interfaces.IJWTService
    {

        private IConfiguration _configuration;
        public JwtHelper(IConfiguration configuration)
        {
             _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration)); ;
        
        
        }

        public   string GenerateToken(User user )
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string GenerateToken(string secret, string issuer, string audience, TimeSpan expiry, Dictionary<string, string> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.UtcNow.Add(expiry),
                SigningCredentials = credentials,
                Claims = claims.ToDictionary(k => k.Key, v => (object)v.Value)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public static string GenerateKey()
        {
            using (var generator = new HMACSHA256())
            {
                var key = generator.Key;
                return Convert.ToBase64String(key);
            }
        }
    }
}
