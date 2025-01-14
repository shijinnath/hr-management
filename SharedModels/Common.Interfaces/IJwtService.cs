using SharedModels;
using System.Collections.Generic;

namespace Common.Interfaces
{
    
    public interface IJWTService
    {
        string GenerateToken(User user);
        string GenerateToken(string secret, string issuer, string audience, TimeSpan expiry, Dictionary<string, string> claims);
    }
}
