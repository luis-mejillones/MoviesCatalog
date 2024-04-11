using MoviesCatalog.Models.Dto;
using MoviesCatalog.Models;
using MoviesCatalog.Services.Helpers;

namespace MoviesCatalog.Services
{
    public interface IMovieService
    {
        Task<Movie?> Add(MovieDto movieDto, string currentUserEmail);
        Task<Movie?> Update(int id, MovieDto movieDto, string currentUserEmail);
        void Delete(int id);
        List<Movie> GetAllMovies();
        PagedResponse<Movie> SearchMovie(
            SearchMovieDto searchMovieDto,
            MovieCategory? category,
            int? release,
            string? sortBy,
            int? pageNumber,
            int? pageSize
        );
    }
}
