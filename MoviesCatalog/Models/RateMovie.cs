namespace MoviesCatalog.Models
{
    public class RateMovie
    {
        public int Id { get; set; }
        public RateType Rate { get; set; }
        public virtual List<Movie>? Movies { get; set;}
        public virtual List<User>? Users { get; set;}
        
    }
}
