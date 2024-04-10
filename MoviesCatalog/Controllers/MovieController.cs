using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Models;
using MoviesCatalog.Models.Dto;
using MoviesCatalog.Services;

namespace MoviesCatalog.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
            
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Movie?> Add(MovieDto movieDto)
        {
            var currentUserEmail = GetCurrentUserEmail();
            var movie = await _movieService.Add(movieDto, currentUserEmail);

            return movie;
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<Movie?> Update(MovieDto movieDto, int id)
        {
            var currentUserEmail = GetCurrentUserEmail();
            var movie = await _movieService.Update(id, movieDto, currentUserEmail);

            return movie;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var currentUserEmail = GetCurrentUserEmail();
            _movieService.Delete(id);

            return Accepted();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public List<Movie> Get()
        {
            return _movieService.GetAllMovies();
        }

        private string GetCurrentUserEmail()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            string userEmail = claimsIdentity.FindFirst(ClaimTypes.Email).Value;

            return userEmail;
        }
    }
}
