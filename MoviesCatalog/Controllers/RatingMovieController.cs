using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Models;
using MoviesCatalog.Models.Dto;
using MoviesCatalog.Services;
using SQLitePCL;

namespace MoviesCatalog.Controllers
{
    [ApiController]
    [Route("api/rating_movie")]
    public class RatingMovieController : Controller
    {
        private readonly RatingMovieService _ratingService;

        public RatingMovieController(RatingMovieService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public IActionResult RateMovie(RateMovieDto rateMovieDto)
        {
            var currentUserEmail = GetCurrentUserEmail();
            var exist = _ratingService.RateMovie(rateMovieDto, currentUserEmail);

            return exist ? BadRequest("User " + currentUserEmail + " already rated this movie.") : Ok("Rate stored.");

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, User")]
        public IActionResult Delete(int id)
        {
            _ratingService.Delete(id);

            return Accepted();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public List<RateMovie> Get()
        {
            return _ratingService.GetAllMovies();
        }

        private string GetCurrentUserEmail()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            string userEmail = claimsIdentity.FindFirst(ClaimTypes.Email).Value;

            return userEmail;
        }
    }
}
