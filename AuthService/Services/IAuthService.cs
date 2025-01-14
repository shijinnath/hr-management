using AuthService.Models;
using System.Threading.Tasks;

namespace AuthService.Interface.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(string email, string password, string fullName);
        Task<User> GetUserByEmail(string email);
    }
}
