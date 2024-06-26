﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Models;
using MoviesCatalog.Models.Dto;
using MoviesCatalog.Services;
using MoviesCatalog.Services.Helpers;

namespace MoviesCatalog.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
            
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Movie>> Add(MovieDto movieDto)
        {
            if (!movieDto.IsValid())
            {
                BadRequest();
            }

            var currentUserEmail = GetCurrentUserEmail();
            var movie = await _movieService.Add(movieDto, currentUserEmail);

            return new ObjectResult(movie) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Movie>> Update(MovieDto movieDto, int id)
        {
            if (!movieDto.IsValid())
            {
                BadRequest();
            }

            var currentUserEmail = GetCurrentUserEmail();
            var movie = await _movieService.Update(id, movieDto, currentUserEmail);

            return new ObjectResult(movie) { StatusCode = StatusCodes.Status202Accepted };
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

        [HttpPost("search")]
        [Authorize(Roles = "Admin, User")]
        public PagedResponse<Movie> SearchMovie(
            SearchMovieDto searchMovieDto, 
            [FromQuery] MovieCategory? category,
            [FromQuery] int? release,
            [FromQuery] string? sort_by,
            [FromQuery] int? page_number = 1,
            [FromQuery] int? page_size = 10
            )
        {
            return _movieService.SearchMovie(
                searchMovieDto, 
                category, 
                release, 
                sort_by, 
                page_number, 
                page_size
            );
        }

        private string GetCurrentUserEmail()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            string userEmail = claimsIdentity.FindFirst(ClaimTypes.Email).Value;

            return userEmail;
        }
    }
}
