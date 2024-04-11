using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Data;
using MoviesCatalog.Models;
using MoviesCatalog.Models.Dto;
using MoviesCatalog.Services.Helpers;


namespace MoviesCatalog.Services
{
    public class LoginService: ILoginService
    {
        private readonly ApplicationDbContext _context;
        private ITokenGenerator _tokenGenerator;

        public LoginService(ApplicationDbContext context, ITokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<User?> GetUser(UserDto userDto)
        {
            return await _context.Users.SingleOrDefaultAsync(
                x => x.Email == userDto.Email && x.Password == userDto.Password
                );
        }

        public string GenerateToken(User user)
        {
            return _tokenGenerator.Generate(user);
        }
    }
}
