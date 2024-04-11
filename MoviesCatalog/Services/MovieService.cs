using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviesCatalog.Data;
using MoviesCatalog.Models;
using MoviesCatalog.Models.Dto;
using MoviesCatalog.Services.Helpers;

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
            return _context.Movies.Include(u => u.User).OrderBy(m => m.Name).ToList();
        }

        public PagedResponse<Movie> SearchMovie(
            SearchMovieDto searchMovieDto, 
            MovieCategory? category, 
            int? release, 
            string? sortBy,
            int? pageNumber,
            int? pageSize
        )
        {
            var movies = from movie in _context.Movies.Include(u => u.User) select movie;

            if (!searchMovieDto.Name.IsNullOrEmpty())
            {
                movies = movies.Where(m => m.Name.ToLower().Contains(searchMovieDto.Name.ToLower()));
            }
            if (!searchMovieDto.Synopsis.IsNullOrEmpty())
            {
                movies = movies.Where(m => m.Synopsis.ToLower().Contains(searchMovieDto.Synopsis.ToLower()));
            }
            if (category != null && release != null)
            {
                movies = movies.Where(m => m.MovieCategory == category && m.ReleaseYear == release);
            }

            if (sortBy == "year.asc")
                movies = movies.OrderBy(m => m.ReleaseYear);
            if (sortBy == "year.desc")
                movies = movies.OrderByDescending(m => m.ReleaseYear);

            if (sortBy == "name.asc")
                movies = movies.OrderBy(m => m.Name);
            if (sortBy == "name.desc")
                movies = movies.OrderByDescending(m => m.Name);
            
            if (sortBy == "date_created.asc")
                movies = movies.OrderBy(m => m.DateCreated);
            if (sortBy == "date_created.desc")
                movies = movies.OrderByDescending(m => m.DateCreated);

            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;

            var totalRecords = movies.Count();
            var data = movies.Skip((int)((pageNumber - 1) * pageSize)).Take((int)pageSize);
            var pagedResponse = new PagedResponse<Movie>(data.ToList(), pageNumber, pageSize, totalRecords);
                
            return pagedResponse;
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
