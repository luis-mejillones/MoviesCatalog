using Microsoft.IdentityModel.Tokens;

namespace MoviesCatalog.Models.Dto
{
    public class MovieDto
    {
        public string Name { get; set; } = null;
        public int ReleaseYear { get; set; }
        public string? Synopsis { get; set; } = null;
        public MovieCategory MovieCategory { get; set; }

        public bool IsValid()
        {
            if (Name.IsNullOrEmpty()) return false;
            if (ReleaseYear < 1900) return false;
            if (MovieCategory == null) return false;

            return true;
        }
    }
}
