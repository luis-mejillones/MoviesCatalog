using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Data;
using MoviesCatalog.Models;
using MoviesCatalog.Models.Dto;

namespace MoviesCatalog.Services
{
    public class RatingMovieService: IRatingMovieService
    {
        private readonly ApplicationDbContext _context;

        public RatingMovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool RateMovie(RateMovieDto rateMovieDto, string currentUserEmail)
        {
            var user = GetCurrentUser(currentUserEmail);

            var movies = _context.RateMovies.Where(m =>
                m.User.Id == user.Id &&
                m.Movie.Id == rateMovieDto.MovieId
            ).ToList();

            if (movies.Count() > 0)
            {
                return true;
            }
            
            var movie = GetMovie(rateMovieDto.MovieId);

            var rateMovie = new RateMovie()
            {
                Rate = rateMovieDto.Rate,
                User = user,
                Movie = movie
            };

            _context.RateMovies.Add(rateMovie);
            _context.SaveChanges();

            return false;

        }

        public void Delete(int id)
        {
            var rateMovie = _context.RateMovies.Where(rm => rm.Id == id).Single();
            _context.RateMovies.Remove(rateMovie);
            _context.SaveChanges();
        }

        public List<RateMovie> GetAllMovies()
        {
            return _context.RateMovies.Include(u => u.User).Include(m => m.Movie).OrderBy(rm => rm.Id).ToList();
        }

        private User GetCurrentUser(string currentUserEmail)
        {
            var user = _context.Users.Where(a => a.Email == currentUserEmail).Single();
            return user;
        }

        private Movie GetMovie(int movieId)
        {
            var movie = _context.Movies.Where(m => m.Id == movieId).Single();

            return movie;
        }
    }
}
