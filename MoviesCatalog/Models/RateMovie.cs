namespace MoviesCatalog.Models
{
    public class RateMovie
    {
        public int Id { get; set; }
        public RateType Rate { get; set; }
        public virtual Movie? Movie { get; set;}
        public virtual User? User { get; set;}
        
    }
}
