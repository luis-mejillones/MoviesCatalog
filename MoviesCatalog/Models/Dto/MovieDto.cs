namespace MoviesCatalog.Models.Dto
{
    public class MovieDto
    {
        //public int Id { get; set; }
        public string Name { get; set; } = null;
        public int ReleaseYear { get; set; }
        public string? Synopsis { get; set; } = null;
        public MovieCategory MovieCategory { get; set; }
    }
}
