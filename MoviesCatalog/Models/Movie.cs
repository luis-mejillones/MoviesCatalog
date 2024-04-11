using System.ComponentModel.DataAnnotations;
using MoviesCatalog.Models.Dto;

namespace MoviesCatalog.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string? Synopsis { get; set; }
        public string? UrlPoster { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual User? User { get; set; }

        public Movie FromDto(MovieDto movieDto)
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

        public Movie UpdateFromDto(MovieDto movieDto)
        {
            Name = movieDto.Name;
            ReleaseYear = movieDto.ReleaseYear;
            Synopsis = movieDto.Synopsis;
            MovieCategory = movieDto.MovieCategory;

            return this;
        }
    }
}
