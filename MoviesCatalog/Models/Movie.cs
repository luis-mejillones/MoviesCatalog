using System.ComponentModel.DataAnnotations;

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
    }
}
