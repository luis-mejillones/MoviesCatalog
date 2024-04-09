using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Data;
using MoviesCatalog.Models;
using MoviesCatalog.Models.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace MoviesCatalog.Services
{
    public class LoginService
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration;
        public LoginService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User?> GetUser(UserDto userDto)
        {
            return await _context.Users.SingleOrDefaultAsync(
                x => x.Email == userDto.Email && x.Password == userDto.Password
                );
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }

        //public async Task<User?> Create(User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return user;
        //}
    }
}
