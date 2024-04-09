using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Domain;
using MoviesCatalog.Models;
using MoviesCatalog.Models.Dto;
using MoviesCatalog.Services;

namespace MoviesCatalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var user = await _loginService.GetUser(userDto);
            
            if (user == null)
            {
                return BadRequest(new { message = "Wrong User/Password." });
            }

            string jwtToken = _loginService.GenerateToken(user);

            return Ok(new { token = jwtToken });
        }

        //[HttpPost("create")]
        //public async Task<IActionResult> Create(User user)
        //{
        //    await _loginService.Create(user);

        //    return Created(string.Empty, user.Id);
        //}
    }
}
