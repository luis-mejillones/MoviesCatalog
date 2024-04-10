using MoviesCatalog.Data;
using MoviesCatalog.Models;
using MoviesCatalog.Models.Dto;

namespace MoviesCatalog.Services
{
    public class MovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movie?> Add(MovieDto movieDto, string currentUserEmail)
        {
            var user = GetCurrentUser(currentUserEmail);
            var movie = GetNewMovie(movieDto);
            movie.User = user;

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie?> Update(int id, MovieDto movieDto, string currentUserEmail)
        {
            var movie = _context.Movies.Where(m => m.Id == id).Single();
            movie = UpdateMovie(movie, movieDto);
            var user = GetCurrentUser(currentUserEmail);
            movie.User = user;

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Where(m => m.Id == id).Single();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public List<Movie> GetAllMovies()
        {
            return _context.Movies.OrderBy(m => m.Name).ToList();
        }

        private Movie GetNewMovie(MovieDto movieDto)
        {
            var movie = new Movie()
            {
                Name = movieDto.Name,
                ReleaseYear = movieDto.ReleaseYear,
                Synopsis = movieDto.Synopsis,
                MovieCategory = movieDto.MovieCategory,
                DateCreated = DateTime.Now,
            };

            return movie;
        }

        private Movie UpdateMovie(Movie movie, MovieDto movieDto)
        {
            movie.Name = movieDto.Name;
            movie.ReleaseYear = movieDto.ReleaseYear;
            movie.Synopsis = movieDto.Synopsis;
            movie.MovieCategory = movieDto.MovieCategory;

            return movie;
        }

        private User GetCurrentUser(string currentUserEmail)
        {
            var user = _context.Users.Where(a => a.Email == currentUserEmail).Single();
            return user;
        }
    }
}
