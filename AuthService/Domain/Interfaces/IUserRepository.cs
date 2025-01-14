
using AuthService.Models;
using System.Threading.Tasks;

namespace AuthenticationService.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }
}
