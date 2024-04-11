using MoviesCatalog.Models.Dto;
using MoviesCatalog.Models;

namespace MoviesCatalog.Services
{
    public interface ILoginService
    {
        Task<User?> GetUser(UserDto userDto);
        string GenerateToken(User user);
    }
}
