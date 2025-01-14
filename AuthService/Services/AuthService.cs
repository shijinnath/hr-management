using AuthService.Data;
using AuthService.Interface.Services;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AuthService.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _dbContext;

        public AuthService(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RegisterUser(string email, string password, string fullName)
        {
            var user = new User
            {
                Email = email,
                Password = password,
                FullName = fullName
            };

            _dbContext.Users.Add(user);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
