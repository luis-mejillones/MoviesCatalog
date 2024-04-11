using MoviesCatalog.Models;
using MoviesCatalog.Models.Dto;

namespace MoviesCatalog.Services
{
    public interface IRatingMovieService
    {
        bool RateMovie(RateMovieDto rateMovieDto, string currentUserEmail);
        void Delete(int id);
        List<RateMovie> GetAllMovies();

    }
}
