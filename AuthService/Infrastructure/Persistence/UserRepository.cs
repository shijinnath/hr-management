using AuthenticationService.Domain.Interfaces;
using AuthService.Data;
using AuthService.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AuthenticationService.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _dbContext;

        public UserRepository(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
