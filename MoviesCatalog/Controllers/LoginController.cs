using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Models.Dto;
using MoviesCatalog.Services;

namespace MoviesCatalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
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
    }
}
